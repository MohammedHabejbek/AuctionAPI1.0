using AuctionAPI1._0.Data;
using AuctionAPI1._0.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace AuctionAPI1._0.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDapperContext _context;

        public UserRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(int id)
        {
            var query = "SELECT * FROM Users WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<User>(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var query = "SELECT * FROM Users";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<User>(query);
            }
        }

        public async Task CreateUser(User user)
        {
            var query = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
            var parameters = new { user.Username, user.Password };

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
