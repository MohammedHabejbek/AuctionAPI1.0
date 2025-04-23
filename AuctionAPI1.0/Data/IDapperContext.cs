using System.Data;

namespace AuctionAPI1._0.Data
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }
}
