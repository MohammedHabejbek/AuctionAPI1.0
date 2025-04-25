using System.Data;
using System.Data.SqlClient;


namespace AuctionAPI1._0.Data
{
    public class DapperContext
    {
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public virtual IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }

}
