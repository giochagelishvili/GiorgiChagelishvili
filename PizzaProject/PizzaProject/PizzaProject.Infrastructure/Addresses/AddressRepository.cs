using Microsoft.Extensions.Options;
using PizzaProject.Application.Repositories;
using PizzaProject.Domain.Entity;
using PizzaProject.Persistence;
using System.Data.SqlClient;

namespace PizzaProject.Infrastructure.Addresses
{
    public class AddressRepository : IAddressRepository
    {
        private readonly string _connection;

        public AddressRepository(IOptions<ConnectionStrings> options)
        {
            _connection = options.Value.DefaultConnection;
        }

        public async Task<List<Address>> GetAll(CancellationToken cancellationToken)
        {
            List<Address> addresses = new List<Address>();

            string selectQuery = "SELECT * FROM Addresses WHERE IsDeleted = @IsDeleted";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);

                command.Parameters.AddWithValue("IsDeleted", false);

                await connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var address = new Address
                    {
                        Id = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        City = reader.GetString(2),
                        Country = reader.GetString(3),
                    };

                    if (!reader.IsDBNull(4))
                        address.Region = reader.GetString(4);

                    if (!reader.IsDBNull(5))
                        address.Description = reader.GetString(5);

                    addresses.Add(address);
                }

                reader.Close();

                return addresses;
            }
        }

        public async Task<Address> Get(int id, CancellationToken cancellationToken)
        {
            string selectQuery = "SELECT * FROM Addresses WHERE Id = @Id AND IsDeleted = @IsDeleted";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);

                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("IsDeleted", false);

                await connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                Address address = null;

                while (await reader.ReadAsync())
                {
                    address = new Address
                    {
                        Id = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        City = reader.GetString(2),
                        Country = reader.GetString(3),
                    };

                    if (!reader.IsDBNull(4))
                        address.Region = reader.GetString(4);

                    if (!reader.IsDBNull(5))
                        address.Description = reader.GetString(5);
                }

                reader.Close();

                return address;
            }
        }

        public async Task Create(Address address, CancellationToken cancellationToken)
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

        public async Task Update(Address address, CancellationToken cancellationToken)
        {
            var updateQuery = "UPDATE Addresses SET City=@City, Country=@Country, Region=@Region, Description=@Description WHERE Id=@id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(updateQuery, connection);

                command.Parameters.AddWithValue("Id", address.Id);
                command.Parameters.AddWithValue("City", address.City);
                command.Parameters.AddWithValue("Country", address.Country);

                if (address.Region != null)
                    command.Parameters.AddWithValue("Region", address.Region);
                else
                    command.Parameters.AddWithValue("Region", DBNull.Value);

                if (address.Description != null)
                    command.Parameters.AddWithValue("Description", address.Description);
                else
                    command.Parameters.AddWithValue("Description", DBNull.Value);

                await connection.OpenAsync();

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<bool> Exists(int id, CancellationToken cancellationToken)
        {
            string countQuery = "SELECT COUNT(*) FROM Addresses WHERE Id = @Id AND IsDeleted = @IsDeleted";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(countQuery, connection);

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
            var deleteQuery = "UPDATE Addresses SET IsDeleted=@IsDeleted WHERE Id=@id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(deleteQuery, connection);

                command.Parameters.AddWithValue("Id", id);
                command.Parameters.AddWithValue("IsDeleted", true);

                await connection.OpenAsync();

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<bool> AddressExistsForUser(int userId, int? addressId, CancellationToken cancellationToken)
        {
            string countQuery = "SELECT COUNT(*) FROM Addresses WHERE Id = @Id AND UserId = @UserId AND IsDeleted = @IsDeleted";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(countQuery, connection);

                command.Parameters.AddWithValue("Id", addressId);
                command.Parameters.AddWithValue("UserId", userId);
                command.Parameters.AddWithValue("IsDeleted", false);

                await connection.OpenAsync();

                var result = await command.ExecuteScalarAsync();

                int count = Convert.ToInt32(result);

                return count > 0;
            }
        }
    }
}
