using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Users.Api.Models;

namespace Users.Api.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserCommunity>().HasKey(uc => new 
            {
                uc.UserId,
                uc.CommunityId
            });

            modelBuilder.Entity<UserCommunity>().HasOne(u=>u.User).WithMany(uc => uc.UserCommunities).HasForeignKey(u => u.UserId);
            modelBuilder.Entity<UserCommunity>().HasOne(c => c.Community).WithMany(uc => uc.UserCommunities).HasForeignKey(c => c.CommunityId );


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Username> Usernames { get; set; }

        public DbSet<Post> Posts {get; set;}

        public DbSet<Community> Communities { get; set; }
        public DbSet<UserCommunity> UserCommunities { get; set; }


           
      
    }
}
