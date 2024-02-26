using Microsoft.Extensions.Options;
using PizzaProject.Application.Repositories;
using PizzaProject.Domain.Entity;
using PizzaProject.Persistence;
using System.Data.SqlClient;

namespace PizzaProject.Infrastructure.Pizzas
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly string _connection;

        public PizzaRepository(IOptions<ConnectionStrings> options)
        {
            _connection = options.Value.DefaultConnection;
        }

        public async Task<List<Pizza>> GetAll(CancellationToken cancellationToken)
        {
            List<Pizza> pizzas = new List<Pizza>();

            string selectQuery = "SELECT * FROM Pizzas WHERE IsDeleted = @IsDeleted";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);

                command.Parameters.AddWithValue("IsDeleted", false);

                await connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var pizza = new Pizza
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetDecimal(2),
                        CaloryCount = reader.GetInt32(4),
                    };

                    if (!reader.IsDBNull(3))
                        pizza.Description = reader.GetString(3);

                    pizzas.Add(pizza);
                }

                reader.Close();

                return pizzas;
            }
        }

        public async Task<Pizza> Get(int id, CancellationToken cancellationToken)
        {
            string selectQuery = "SELECT * FROM Pizzas WHERE Id = @Id AND IsDeleted = @IsDeleted";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);

                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("IsDeleted", false);

                await connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                Pizza pizza = null;

                while (await reader.ReadAsync())
                {
                    pizza = new Pizza
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Price = reader.GetDecimal(2),
                        CaloryCount = reader.GetInt32(4),
                    };

                    if (!reader.IsDBNull(3))
                        pizza.Description = reader.GetString(3);
                }

                reader.Close();

                return pizza;
            }
        }

        public async Task Create(Pizza pizza, CancellationToken cancellationToken)
        {
            string insertQuery = "INSERT INTO Pizzas VALUES(@Name, @Price, @Description, @CaloryCount, @IsDeleted)";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(insertQuery, connection);

                command.Parameters.AddWithValue("Name", pizza.Name);
                command.Parameters.AddWithValue("Price", pizza.Price);
                command.Parameters.AddWithValue("IsDeleted", false);

                if (pizza.Description != null)
                    command.Parameters.AddWithValue("Description", pizza.Description);
                else
                    command.Parameters.AddWithValue("Description", DBNull.Value);

                command.Parameters.AddWithValue("CaloryCount", pizza.CaloryCount);

                await connection.OpenAsync();

                await command.ExecuteScalarAsync();
            }
        }

        public async Task Update(Pizza pizza, CancellationToken cancellationToken)
        {
            var updateQuery = "UPDATE Pizzas SET Name=@Name, Price=@Price, Description=@Description, CaloryCount=@CaloryCount where Id=@Id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(updateQuery, connection);

                command.Parameters.AddWithValue("Id", pizza.Id);
                command.Parameters.AddWithValue("Name", pizza.Name);
                command.Parameters.AddWithValue("Price", pizza.Price);

                if (pizza.Description != null)
                    command.Parameters.AddWithValue("Description", pizza.Description);
                else
                    command.Parameters.AddWithValue("Description", DBNull.Value);

                command.Parameters.AddWithValue("CaloryCount", pizza.CaloryCount);

                await connection.OpenAsync();

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdatePrice(int id, decimal price, CancellationToken cancellationToken)
        {
            var countQuery = "UPDATE Pizzas SET Price=@Price WHERE Id=@Id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(countQuery, connection);

                command.Parameters.AddWithValue("Price", price);
                command.Parameters.AddWithValue("Id", id);

                await connection.OpenAsync();

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<bool> Exists(int id, CancellationToken cancellationToken)
        {
            string updateQuery = "SELECT COUNT(*) FROM Pizzas WHERE Id = @Id AND IsDeleted = @IsDeleted";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(updateQuery, connection);

                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("IsDeleted", false);

                await connection.OpenAsync();

                var result = await command.ExecuteScalarAsync();

                int count = Convert.ToInt32(result);

                return count > 0;
            }
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var deleteQuery = "UPDATE Pizzas SET IsDeleted=@IsDeleted WHERE Id=@Id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(deleteQuery, connection);

                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("IsDeleted", true);

                await connection.OpenAsync();

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
