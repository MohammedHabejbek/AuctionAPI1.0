using Xunit;
using AuctionAPI1._0.Models;

namespace AuctionAPI1._0.Tests
{
    public class BidTests
    {
        [Fact]
        public void CanCreateBid_WithValidData()
        {
            // Arrange
            var bid = new Bid
            {
                Id = 1,
                Price = 200,
                UserId = 3,
                AuctionId = 5
            };

            // Act & Assert
            Assert.Equal(1, bid.Id);
            Assert.Equal(200, bid.Price);
            Assert.Equal(3, bid.UserId);
            Assert.Equal(5, bid.AuctionId);
        }
    }
}
