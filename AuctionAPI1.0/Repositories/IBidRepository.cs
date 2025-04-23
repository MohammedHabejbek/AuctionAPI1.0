using AuctionAPI1._0.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuctionAPI1._0.Repositories
{
    public interface IBidRepository
    {
        Task<IEnumerable<Bid>> GetBidsForAuction(int auctionId);
        Task CreateBid(Bid bid);
        Task DeleteBid(int id);
    }
}

