using Microsoft.EntityFrameworkCore;
using Users.Api.Models;

namespace Users.Api.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        
           public DbSet<User> Users { get; set; }
        
      
    }
}
