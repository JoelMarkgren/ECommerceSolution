using ECommerceProject.Dto;
using ECommerceProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        //public DbSet<User> Users { get; set; }
        public DbSet<Cellphone> Cellphones { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",
                    Id = "a9925f7a-c5df-4a8c-b3ef-1bf818990b61"
                },
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    Id = "dce33b6a-cf4e-4e35-8567-963782128c9c"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
