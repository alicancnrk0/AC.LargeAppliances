using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AC.LargeAppliances.Models.Entities
{
    [Table("ProductFeatures")]
    public class ProductFeature
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string? Value { get; set; }
        public int SortOrder { get; set; }

        public Product? Product { get; set; }
    }
}
