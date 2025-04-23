using AuctionAPI1._0.Data;
using AuctionAPI1._0.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace AuctionAPI1._0.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly DapperContext _context;

        public BidRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bid>> GetBidsForAuction(int auctionId)
        {
            var query = "SELECT * FROM Bids WHERE AuctionId = @AuctionId";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Bid>(query, new { AuctionId = auctionId });
            }
        }

        public async Task CreateBid(Bid bid)
        {
            var query = @"INSERT INTO Bids (BidAmount, BidTime, AuctionId, UserId)
                          VALUES (@BidAmount, @BidTime, @AuctionId, @UserId)";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, bid);
            }
        }

        public async Task DeleteBid(int id)
        {
            var query = "DELETE FROM Bids WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}
