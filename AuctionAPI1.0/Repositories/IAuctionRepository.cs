using AuctionAPI1._0.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuctionAPI1._0.Repositories
{
    public interface IAuctionRepository
    {
        Task<Auction> GetAuctionById(int id);
        Task<IEnumerable<Auction>> GetAllAuctions();
        Task CreateAuction(Auction auction);
        Task UpdateAuction(Auction auction);
        Task DeleteAuction(int id);
    }
}
