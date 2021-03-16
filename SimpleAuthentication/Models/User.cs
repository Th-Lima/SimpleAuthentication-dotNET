using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleAuthentication.Models
{
    public class User
    {
        public User(int id, string name, string password, bool isAdmin)
        {
            Id = id;
            Name = name;
            Password = password;
            IsAdmin = isAdmin;
        }

        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Password { get; set; }
        
        public bool IsAdmin { get; set; }
    }
}
