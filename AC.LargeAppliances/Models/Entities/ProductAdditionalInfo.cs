using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AC.LargeAppliances.Models.Entities
{
    [Table("ProductAdditionalInfos")]
    public class ProductAdditionalInfo
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }

        public Product? Product { get; set; }
    }
}
