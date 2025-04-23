using AuctionAPI1._0.Data;
using AuctionAPI1._0.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace AuctionAPI1._0.Repositories
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly DapperContext _context;

        public AuctionRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Auction> GetAuctionById(int id)
        {
            var query = "SELECT * FROM Auctions WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Auction>(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<Auction>> GetAllAuctions()
        {
            var query = "SELECT * FROM Auctions";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Auction>(query);
            }
        }

        public async Task CreateAuction(Auction auction)
        {
            var query = @"INSERT INTO Auctions (Title, Description, StartPrice, StartDate, EndDate, CreatedByUserId)
                          VALUES (@Title, @Description, @StartPrice, @StartDate, @EndDate, @CreatedByUserId)";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, auction);
            }
        }

        public async Task UpdateAuction(Auction auction)
        {
            var query = @"UPDATE Auctions
                          SET Title = @Title, Description = @Description, StartPrice = @StartPrice, 
                              StartDate = @StartDate, EndDate = @EndDate
                          WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, auction);
            }
        }

        public async Task DeleteAuction(int id)
        {
            var query = "DELETE FROM Auctions WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
