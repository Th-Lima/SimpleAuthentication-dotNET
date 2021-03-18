using Microsoft.AspNetCore.Http;

namespace SimpleAuthentication.Lib.Session
{
    public class Session
    {
        private IHttpContextAccessor _context;

        public Session(IHttpContextAccessor context)
        {
            _context = context;
        }

        public void Register(string key, string value)
        {
            _context.HttpContext.Session.SetString(key, value);
        }

        public string Consult(string key)
        {
            return _context.HttpContext.Session.GetString(key);
        }

        public bool IsExisting(string key)
        {
            if (_context.HttpContext.Session.GetString(key) == null) { return false; }

            return true;
        }

        public void RemoveAll()
        {
            _context.HttpContext.Session.Clear();
        }
    }
}
