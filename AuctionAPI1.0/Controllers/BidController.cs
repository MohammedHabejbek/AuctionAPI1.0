using Microsoft.AspNetCore.Mvc;
using AuctionAPI1._0.Repositories;
using AuctionAPI1._0.Models;

namespace AuctionAPI1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly IBidRepository _bidRepository;

        public BidController(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }

        [HttpGet("{auctionId}")]
        public async Task<ActionResult<IEnumerable<Bid>>> GetBidsForAuction(int auctionId)
        {
            var bids = await _bidRepository.GetBidsForAuction(auctionId);
            return Ok(bids);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBid(Bid bid)
        {
            await _bidRepository.CreateBid(bid);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBid(int id)
        {
            await _bidRepository.DeleteBid(id);
            return NoContent();
        }
    }
}

