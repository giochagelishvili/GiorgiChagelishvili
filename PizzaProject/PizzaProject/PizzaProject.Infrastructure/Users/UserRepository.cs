using Microsoft.Extensions.Options;
using PizzaProject.Application.Repositories;
using PizzaProject.Domain.Entity;
using PizzaProject.Persistence;
using System.Data.SqlClient;

namespace PizzaProject.Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connection;

        public UserRepository(IOptions<ConnectionStrings> options)
        {
            _connection = options.Value.DefaultConnection;
        }

        public async Task<List<User>> GetAll(CancellationToken cancellationToken)
        {
            List<User> users = new List<User>();

            string selectQuery = "SELECT * FROM Users WHERE IsDeleted = @IsDeleted";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);

                command.Parameters.AddWithValue("IsDeleted", false);

                await connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var user = new User
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                    };

                    users.Add(user);
                }

                reader.Close();

                foreach (var user in users)
                {
                    List<Address> addresses = new List<Address>();

                    string selectAddressesQuery = "SELECT * FROM Addresses WHERE UserId = @UserId AND IsDeleted = @IsDeleted";

                    SqlCommand addressCommand = new SqlCommand(selectAddressesQuery, connection);

                    addressCommand.Parameters.AddWithValue("UserId", user.Id);
                    addressCommand.Parameters.AddWithValue("IsDeleted", false);

                    SqlDataReader addressReader = await addressCommand.ExecuteReaderAsync();

                    while (await addressReader.ReadAsync())
                    {
                        Address address = new Address
                        {
                            Id = addressReader.GetInt32(0),
                            UserId = addressReader.GetInt32(1),
                            City = addressReader.GetString(2),
                            Country = addressReader.GetString(3),
                        };

                        if (!addressReader.IsDBNull(4))
                            address.Region = addressReader.GetString(4);

                        if (!addressReader.IsDBNull(5))
                            address.Description = addressReader.GetString(5);

                        addresses.Add(address);
                    }

                    addressReader.Close();

                    if (addresses.Count > 0)
                        user.Address = addresses;
                }

                reader.Close();

                return users;
            }
        }

        public async Task<User> Get(int id, CancellationToken cancellationToken)
        {
            User user = null;

            string selectQuery = "SELECT * FROM Users WHERE IsDeleted = @IsDeleted AND Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);

                command.Parameters.AddWithValue("IsDeleted", false);
                command.Parameters.AddWithValue("Id", id);

                await connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    user = new User
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Email = reader.GetString(3),
                        PhoneNumber = reader.GetString(4),
                    };
                }

                reader.Close();

                List<Address> addresses = new List<Address>();

                string selectAddressesQuery = "SELECT * FROM Addresses WHERE UserId = @UserId AND IsDeleted = @IsDeleted";

                SqlCommand addressCommand = new SqlCommand(selectAddressesQuery, connection);

                addressCommand.Parameters.AddWithValue("UserId", user.Id);
                addressCommand.Parameters.AddWithValue("IsDeleted", false);

                SqlDataReader addressReader = await addressCommand.ExecuteReaderAsync();

                while (await addressReader.ReadAsync())
                {
                    Address address = new Address
                    {
                        Id = addressReader.GetInt32(0),
                        UserId = addressReader.GetInt32(1),
                        City = addressReader.GetString(2),
                        Country = addressReader.GetString(3),
                    };

                    if (!addressReader.IsDBNull(4))
                        address.Region = addressReader.GetString(4);

                    if (!addressReader.IsDBNull(5))
                        address.Description = addressReader.GetString(5);

                    addresses.Add(address);
                }

                addressReader.Close();

                if (addresses.Count > 0)
                    user.Address = addresses;

                reader.Close();

                return user;
            }
        }

        public async Task Create(User user, CancellationToken cancellationToken)
        {
            string insertQuery = "INSERT INTO Users (FirstName, LastName, Email, PhoneNumber, IsDeleted) OUTPUT INSERTED.Id VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @IsDeleted)";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(insertQuery, connection);

                command.Parameters.AddWithValue("FirstName", user.FirstName);
                command.Parameters.AddWithValue("LastName", user.LastName);
                command.Parameters.AddWithValue("Email", user.Email);
                command.Parameters.AddWithValue("PhoneNumber", user.PhoneNumber);
                command.Parameters.AddWithValue("IsDeleted", false);

                await connection.OpenAsync();

                var userId = await command.ExecuteScalarAsync();

                if (user.Address != null)
                {
                    foreach (var address in user.Address)
                    {
                        address.UserId = Convert.ToInt32(userId);
                        await CreateAddress(address);
                    }
                }
            }
        }

        private async Task CreateAddress(Address address)
        {
            string insertQuery = "INSERT INTO Addresses VALUES(@UserId, @City, @Country, @Region, @Description, @IsDeleted)";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(insertQuery, connection);

                command.Parameters.AddWithValue("UserId", address.UserId);
                command.Parameters.AddWithValue("City", address.City);
                command.Parameters.AddWithValue("Country", address.Country);
                command.Parameters.AddWithValue("IsDeleted", false);

                if (address.Region != null)
                    command.Parameters.AddWithValue("Region", address.Region);
                else
                    command.Parameters.AddWithValue("Region", DBNull.Value);

                if (address.Description != null)
                    command.Parameters.AddWithValue("Description", address.Description);
                else
                    command.Parameters.AddWithValue("Description", DBNull.Value);

                await connection.OpenAsync();

                await command.ExecuteScalarAsync();
            }
        }

        public async Task Update(User user, CancellationToken cancellationToken)
        {
            var updateQuery = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PhoneNumber = @PhoneNumber WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(updateQuery, connection);

                command.Parameters.AddWithValue("Id", user.Id);
                command.Parameters.AddWithValue("FirstName", user.FirstName);
                command.Parameters.AddWithValue("LastName", user.LastName);
                command.Parameters.AddWithValue("Email", user.Email);
                command.Parameters.AddWithValue("PhoneNumber", user.PhoneNumber);

                await connection.OpenAsync();

                await command.ExecuteNonQueryAsync();
            }

            if (user.Address != null && user.Address.Count > 0)
            {
                foreach (var address in user.Address)
                {
                    address.UserId = user.Id;
                    await CreateAddress(address);
                }
            }
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var deleteQuery = "UPDATE Users SET IsDeleted = @IsDeleted WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(deleteQuery, connection);

                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("IsDeleted", true);

                await connection.OpenAsync();

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<bool> Exists(int id, CancellationToken cancellationToken)
        {
            string selectQuery = "SELECT COUNT(*) FROM Users WHERE Id = @Id AND IsDeleted = @IsDeleted";

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
    }
}
