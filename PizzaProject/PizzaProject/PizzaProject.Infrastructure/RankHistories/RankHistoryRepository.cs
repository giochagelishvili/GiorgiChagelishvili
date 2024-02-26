using Microsoft.Extensions.Options;
using PizzaProject.Application.Repositories;
using PizzaProject.Domain.Entity;
using PizzaProject.Persistence;
using System.Data.Common;
using System.Data.SqlClient;

namespace PizzaProject.Infrastructure.RankHistories
{
    public class RankHistoryRepository : IRankHistoryRepository
    {
        private readonly string _connection;

        public RankHistoryRepository(IOptions<ConnectionStrings> options)
        {
            _connection = options.Value.DefaultConnection;
        }

        public async Task<List<RankHistory>> GetAll(CancellationToken cancellationToken)
        {
            List<RankHistory> rankHistories = new List<RankHistory>();

            string selectQuery = "SELECT * FROM RankHistory";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);

                await connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var rankHistory = new RankHistory
                    {
                        Id = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        PizzaId = reader.GetInt32(2),
                        Rank = reader.GetInt32(3),
                    };

                    rankHistories.Add(rankHistory);
                }

                reader.Close();

                return rankHistories;
            }
        }

        public async Task<RankHistory> Get(int id, CancellationToken cancellationToken)
        {
            RankHistory rankHistory = null;

            string selectQuery = "SELECT * FROM RankHistory WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);

                command.Parameters.AddWithValue("Id", id);

                await connection.OpenAsync();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    rankHistory = new RankHistory
                    {
                        Id = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        PizzaId = reader.GetInt32(2),
                        Rank = reader.GetInt32(3),
                    };
                }

                reader.Close();

                return rankHistory;
            }
        }

        public async Task Create(RankHistory rankHistory, CancellationToken cancellationToken)
        {
            string insertQuery = "INSERT INTO RankHistory VALUES(@UserId, @PizzaId, @Rank)";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(insertQuery, connection);

                command.Parameters.AddWithValue("UserId", rankHistory.UserId);
                command.Parameters.AddWithValue("PizzaId", rankHistory.PizzaId);
                command.Parameters.AddWithValue("Rank", rankHistory.Rank);

                await connection.OpenAsync();

                await command.ExecuteScalarAsync();
            }
        }

        public async Task<bool> Exists(int id, CancellationToken cancellationToken)
        {
            string updateQuery = "SELECT COUNT(*) FROM RankHistory WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(updateQuery, connection);

                command.Parameters.AddWithValue("Id", id);

                await connection.OpenAsync();

                var result = await command.ExecuteScalarAsync();

                int count = Convert.ToInt32(result);

                return count > 0;
            }
        }
    }
}
