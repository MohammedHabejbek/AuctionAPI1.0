using Microsoft.AspNetCore.Mvc;
using AuctionAPI1._0.Repositories;
using AuctionAPI1._0.Models;
using Microsoft.AspNetCore.Authorization;

namespace AuctionAPI1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionRepository _auctionRepository;

        public AuctionController(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Auction>> GetAuctionById(int id)
        {
            var auction = await _auctionRepository.GetAuctionById(id);
            if (auction == null) return NotFound();
            return Ok(auction);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Auction>>> GetAllAuctions()
        {
            var auctions = await _auctionRepository.GetAllAuctions();
            return Ok(auctions);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CreateAuction(Auction auction)
        {
            await _auctionRepository.CreateAuction(auction);
            return Ok();
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpdateAuction(Auction auction)
        {
            await _auctionRepository.UpdateAuction(auction);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuction(int id)
        {
            await _auctionRepository.DeleteAuction(id);
            return NoContent();
        }
    }
}
