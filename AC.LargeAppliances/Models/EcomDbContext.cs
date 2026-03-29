using AC.LargeAppliances.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AC.LargeAppliances.Models
{
    public class EcomDbContext : DbContext
    {

        public EcomDbContext() { }

        public EcomDbContext(DbContextOptions<EcomDbContext> options) : base(options) { }

        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Card> Cards { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlServer("Server=127.0.0.1;User Id=sa;Password=11;Database=EcomDb;Encrypt=False;");
            base.OnConfiguring(optionsBuilder);
        }


    }
}
