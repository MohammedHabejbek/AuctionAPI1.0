using AuctionAPI1._0.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuctionAPI1._0.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetAllUsers();
        Task CreateUser(User user);
    }
}
