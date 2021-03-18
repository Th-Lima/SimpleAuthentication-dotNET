using SimpleAuthentication.Data;
using SimpleAuthentication.Models;
using SimpleAuthentication.Repositories.Contracts;
using System.Linq;

namespace SimpleAuthentication.Repositories
{
    public class UserRepository : IUserRepository
    {
        public SimpleAuthenticationContext _db;

        public UserRepository(SimpleAuthenticationContext db)
        {
            _db = db;
        }

        public User Login(string name, string password)
        {
            User user = _db.Users.Where(u => u.Name == name && u.Password == password).FirstOrDefault();

            return user;
        }
    }
}
