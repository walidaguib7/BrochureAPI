using BrochureAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BrochureAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
            
        }

        public DbSet<Services> Services { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
