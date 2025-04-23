using Xunit;
using AuctionAPI1._0.Models;

namespace AuctionAPI1._0.Tests
{
    public class UserTests
    {
        [Fact]
        public void CanCreateUser_WithValidData()
        {
            // Arrange
            var user = new User
            {
                Username = "Yahharen",
                Password = "Nurdin0809"
            };

            // Act & Assert
            Assert.Equal("Yahharen", user.Username);
            Assert.Equal("Nurdin0809", user.Password);
        }
    }
}
