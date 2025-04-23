using Xunit;
using AuctionAPI1._0.Models;
using System;

namespace AuctionAPI1._0.Tests
{
    public class AuctionTests
    {
        [Fact]
        public void CanCreateAuction_WithValidData()
        {
            // Arrange
            var auction = new Auction
            {
                Title = "Gaming Laptop",
                Description = "RTX 4080, 32GB RAM",
                StartPrice = 1500,
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(5),
                CreatedByUserId = 1
            };

            // Act & Assert
            Assert.Equal("Gaming Laptop", auction.Title);
            Assert.Equal(1500, auction.StartPrice);
            Assert.Equal(1, auction.CreatedByUserId);
        }
    }
}
