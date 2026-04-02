using AC.LargeAppliances.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AC.LargeAppliances.Models
{
    public class EcomDbContext : DbContext
    {

        public EcomDbContext() { }

        public EcomDbContext(DbContextOptions<EcomDbContext> options) : base(options) { }

        public DbSet<Discount> Discounts { get; set; }
        public DbSet<CardItem> CardItems { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Contactpage> Contactpages { get; set; }
        public DbSet<DiscountRequest> DiscountRequests { get; set; }
        public DbSet<ContactRequest> ContactRequests { get; set; }
        public DbSet<AboutPage> AboutPages { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorPage> VendorPages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductAdditionalInfo> ProductAdditionalInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlServer("Server=127.0.0.1;User Id=sa;Password=11;Database=EcomDb;Encrypt=False;");
            base.OnConfiguring(optionsBuilder);
        }


    }
}
