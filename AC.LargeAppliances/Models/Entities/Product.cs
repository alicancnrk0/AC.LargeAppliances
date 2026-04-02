using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AC.LargeAppliances.Models.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? VendorId { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }
        public int? StarsCount { get; set; }
        public string? SKU { get; set; }
        public string? Tags { get; set; }
        public string? Description { get; set; }

      
        public Vendor? Vendor { get; set; }
        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public ICollection<ProductFeature> Features { get; set; } = new List<ProductFeature>();
        public ICollection<ProductAdditionalInfo> AdditionalInfos { get; set; } = new List<ProductAdditionalInfo>();
    }
}
