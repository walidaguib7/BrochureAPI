using BrochureAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BrochureAPI.Data
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
            
        }

        public DbSet<BrochureAPI.Models.Services> Services { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<FilesModel> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            List<IdentityRole> roles =
           [
               new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "user",
                    NormalizedName = "USER"
                }
           ];
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
