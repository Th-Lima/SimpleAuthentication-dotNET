using Newtonsoft.Json;
using SimpleAuthentication.Models;

namespace SimpleAuthentication.Lib.Login
{
    public class UserLogin
    {
        private Session.Session _session;
        private const string Key = "Login.User";

        public UserLogin(Session.Session session)
        {
            _session = session;
        }

        public void Login(User user)
        {
            string userJSONString = JsonConvert.SerializeObject(user);

            _session.Register(Key, userJSONString);
        }

        public void Logout()
        {
            _session.RemoveAll();
        }

        public User GetUser()
        {
            if (_session.IsExisting(Key))
            {
                string userJSONString = _session.Consult(Key);
                return JsonConvert.DeserializeObject<User>(userJSONString);
            }
            else
            {
                return null;
            }
        }
    }
}
