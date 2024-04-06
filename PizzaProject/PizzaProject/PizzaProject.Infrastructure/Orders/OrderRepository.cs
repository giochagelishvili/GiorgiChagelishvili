using Microsoft.Extensions.Options;
using PizzaProject.Application.Repositories;
using PizzaProject.Domain.Entity;
using PizzaProject.Persistence;
using System.Data.SqlClient;

namespace PizzaProject.Infrastructure.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connection;

        public OrderRepository(IOptions<ConnectionStrings> options)
        {
            _connection = options.Value.DefaultConnection;
        }

        public async Task<List<Order>> GetAll(CancellationToken cancellationToken)
        {
            List<Order> orders = new();

            string selectQuery = "SELECT * FROM Orders WHERE IsDeleted = @IsDeleted";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);

                command.Parameters.AddWithValue("IsDeleted", false);

                await connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var order = new Order
                    {
                        Id = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                    };

                    if (!reader.IsDBNull(2))
                        order.AddressId = reader.GetInt32(2);

                    orders.Add(order);
                }

                reader.Close();

                foreach (var order in orders)
                {
                    List<int> pizzaIds = new();

                    string selectPizzaIdQuery = "SELECT PizzaId FROM OrderedPizzas WHERE OrderId = @OrderId AND IsDeleted = @IsDeleted";

                    SqlCommand pizzaIdCommand = new SqlCommand(selectPizzaIdQuery, connection);

                    pizzaIdCommand.Parameters.AddWithValue("OrderId", order.Id);
                    pizzaIdCommand.Parameters.AddWithValue("IsDeleted", false);

                    SqlDataReader pizzaIdReader = await pizzaIdCommand.ExecuteReaderAsync();

                    while (await pizzaIdReader.ReadAsync())
                    {
                        pizzaIds.Add(pizzaIdReader.GetInt32(0));
                    }

                    pizzaIdReader.Close();

                    List<Pizza> pizzas = new();

                    foreach (int pizzaId in pizzaIds)
                    {
                        string selectPizzaQuery = "SELECT * FROM Pizzas WHERE Id = @Id AND IsDeleted = @IsDeleted";

                        SqlCommand pizzaCommand = new SqlCommand(selectPizzaQuery, connection);

                        pizzaCommand.Parameters.AddWithValue("Id", pizzaId);
                        pizzaCommand.Parameters.AddWithValue("IsDeleted", false);

                        SqlDataReader pizzaReader = await pizzaCommand.ExecuteReaderAsync();

                        while (await pizzaReader.ReadAsync())
                        {
                            var pizza = new Pizza
                            {
                                Id = pizzaReader.GetInt32(0),
                                Name = pizzaReader.GetString(1),
                                Price = pizzaReader.GetDecimal(2),
                                CaloryCount = pizzaReader.GetInt32(4)
                            };

                            if (!pizzaReader.IsDBNull(3))
                                pizza.Description = pizzaReader.GetString(3);

                            pizzas.Add(pizza);
                        }

                        pizzaReader.Close();
                    }

                    order.Pizzas = pizzas;
                }

                return orders;
            }
        }

        public async Task<Order> Get(int id, CancellationToken cancellationToken)
        {
            Order order = null;

            string selectQuery = "SELECT * FROM Orders WHERE Id = @Id AND IsDeleted = @IsDeleted";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);

                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("IsDeleted", false);

                await connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    order = new Order
                    {
                        Id = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                    };

                    if (!reader.IsDBNull(2))
                        order.AddressId = reader.GetInt32(2);
                }

                reader.Close();

                List<int> pizzaIds = new();

                string selectPizzaIdQuery = "SELECT PizzaId FROM OrderedPizzas WHERE OrderId = @OrderId AND IsDeleted = @IsDeleted";

                SqlCommand pizzaIdCommand = new SqlCommand(selectPizzaIdQuery, connection);

                pizzaIdCommand.Parameters.AddWithValue("OrderId", order.Id);
                pizzaIdCommand.Parameters.AddWithValue("IsDeleted", false);

                SqlDataReader pizzaIdReader = await pizzaIdCommand.ExecuteReaderAsync();

                while (await pizzaIdReader.ReadAsync())
                {
                    pizzaIds.Add(pizzaIdReader.GetInt32(0));
                }

                pizzaIdReader.Close();

                List<Pizza> pizzas = new();

                foreach (int pizzaId in pizzaIds)
                {
                    string selectPizzaQuery = "SELECT * FROM Pizzas WHERE Id = @Id AND IsDeleted = @IsDeleted";

                    SqlCommand pizzaCommand = new SqlCommand(selectPizzaQuery, connection);

                    pizzaCommand.Parameters.AddWithValue("Id", pizzaId);
                    pizzaCommand.Parameters.AddWithValue("IsDeleted", false);

                    SqlDataReader pizzaReader = await pizzaCommand.ExecuteReaderAsync();

                    while (await pizzaReader.ReadAsync())
                    {
                        var pizza = new Pizza
                        {
                            Id = pizzaReader.GetInt32(0),
                            Name = pizzaReader.GetString(1),
                            Price = pizzaReader.GetDecimal(2),
                            CaloryCount = pizzaReader.GetInt32(4)
                        };

                        if (!pizzaReader.IsDBNull(3))
                            pizza.Description = pizzaReader.GetString(3);

                        pizzas.Add(pizza);
                    }

                    pizzaReader.Close();

                    order.Pizzas = pizzas;
                }

                return order;
            }
        }

        public async Task Create(Order order, CancellationToken cancellationToken)
        {
            string insertQuery = "INSERT INTO Orders (UserId, AddressId, IsDeleted) OUTPUT INSERTED.Id VALUES (@UserId, @AddressId, @IsDeleted)";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(insertQuery, connection);

                command.Parameters.AddWithValue("UserId", order.UserId);
                command.Parameters.AddWithValue("AddressId", order.AddressId);
                command.Parameters.AddWithValue("IsDeleted", false);

                await connection.OpenAsync();

                var result = await command.ExecuteScalarAsync();
                var orderId = Convert.ToInt32(result);

                insertQuery = "INSERT INTO OrderedPizzas VALUES(@OrderId, @PizzaId, @IsDeleted)";

                foreach (var orderedPizza in order.PizzaIds)
                {
                    command = new SqlCommand(insertQuery, connection);

                    command.Parameters.AddWithValue("OrderId", orderId);
                    command.Parameters.AddWithValue("PizzaId", orderedPizza);
                    command.Parameters.AddWithValue("IsDeleted", false);

                    await command.ExecuteScalarAsync();
                }
            }
        }

        public async Task<bool> Exists(int id, CancellationToken cancellationToken)
        {
            string selectQuery = "SELECT COUNT(*) FROM Orders WHERE Id = @Id AND IsDeleted = @IsDeleted";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);

                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("IsDeleted", false);

                await connection.OpenAsync();

                var result = await command.ExecuteScalarAsync();

                int count = Convert.ToInt32(result);

                return count > 0;
            }
        }

        public async Task<bool> UserOrderedPizza(int userId, int pizzaId, CancellationToken cancellationToken)
        {
            string selectQuery = "SELECT * FROM Orders WHERE UserId = @UserId AND IsDeleted = @IsDeleted";

            List<int> orderIds = new();

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);

                command.Parameters.AddWithValue("UserId", userId);
                command.Parameters.AddWithValue("IsDeleted", false);

                await connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    orderIds.Add(reader.GetInt32(0));
                }

                reader.Close();

                int count = 0;

                string selectCountQuery = "SELECT COUNT(*) FROM OrderedPizzas WHERE OrderId = @OrderId AND PizzaId = @PizzaId AND IsDeleted = @IsDeleted";

                foreach (int orderId in orderIds)
                {
                    SqlCommand selectCountCommand = new SqlCommand(selectCountQuery, connection);

                    selectCountCommand.Parameters.AddWithValue("OrderId", orderId);
                    selectCountCommand.Parameters.AddWithValue("PizzaId", pizzaId);
                    selectCountCommand.Parameters.AddWithValue("IsDeleted", false);

                    var result = await selectCountCommand.ExecuteScalarAsync();

                    count += Convert.ToInt32(result);

                    if (count > 0)
                        return true;
                }

                return count > 0;
            }
        }
    }
}
