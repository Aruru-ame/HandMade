using Microsoft.EntityFrameworkCore;
using HandMade.Shared.Models;

namespace HandMade.Server.Data
{
    public class AppDbContext : DbContext
    {        
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<WorksSearch> WorksSearch { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("");
        }
    }
}