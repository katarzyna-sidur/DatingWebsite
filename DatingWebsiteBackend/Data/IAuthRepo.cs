using System.Threading.Tasks;
using DatingWebsiteBackend.Models;

namespace DatingWebsiteBackend.Data
{
    public interface IAuthRepo
    {
        Task<User> Login(string username, string password);
        Task<User> Register(User user, string password);
        Task<bool> UserExsist(string username);
    }
}