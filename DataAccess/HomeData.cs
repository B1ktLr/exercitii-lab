using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class HomeData
    {
        private readonly string _connectionString;

        public HomeData(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> InsertHomeAsync(Home home)
        {
            const string sql = "INSERT INTO Homes (Adresa, Suprafata) VALUES (@Adresa, @Suprafata); SELECT CAST(SCOPE_IDENTITY() as int)";
            using var connection = new SqlConnection(_connectionString);
            return await connection.ExecuteScalarAsync<int>(sql, home);
        }

        public async Task<IEnumerable<Home>> GetAllHomesAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Home>("SELECT * FROM Homes");
        }

        public async Task<Home> GetHomeByIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QuerySingleOrDefaultAsync<Home>("SELECT * FROM Homes WHERE ID = @ID", new { ID = id });
        }

        public async Task<bool> UpdateHomeAsync(Home home)
        {
            const string sql = "UPDATE Homes SET Adresa = @Adresa, Suprafata = @Suprafata WHERE ID = @ID";
            using var connection = new SqlConnection(_connectionString);
            int rows = await connection.ExecuteAsync(sql, home);
            return rows > 0;
        }

        public async Task<bool> DeleteHomeAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            int rows = await connection.ExecuteAsync("DELETE FROM Homes WHERE ID = @ID", new { ID = id });
            return rows > 0;
        }
    }
}
