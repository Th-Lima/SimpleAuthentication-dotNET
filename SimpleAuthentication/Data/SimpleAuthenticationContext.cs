using Microsoft.EntityFrameworkCore;
using SimpleAuthentication.Models;
using System.Collections.Generic;

namespace SimpleAuthentication.Data
{
    public class SimpleAuthenticationContext : DbContext
    {
        public SimpleAuthenticationContext(DbContextOptions<SimpleAuthenticationContext> options) : base(options){}

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new List<User>()
            {
                new User(1, "User01", "123456", true),
                new User(2, "User02", "123456", false)
            });
        }
    }
}
