namespace AuctionAPI1._0.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public decimal BidAmount { get; set; }
        public DateTime BidTime { get; set; }
        public int AuctionId { get; set; }
        public int UserId { get; set; }
        public decimal Price { get; set; }
    }
}
