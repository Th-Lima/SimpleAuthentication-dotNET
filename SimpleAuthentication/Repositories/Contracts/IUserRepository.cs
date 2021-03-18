using SimpleAuthentication.Models;

namespace SimpleAuthentication.Repositories.Contracts
{
    public interface IUserRepository
    {
        User Login(string name, string password);
    }
}
