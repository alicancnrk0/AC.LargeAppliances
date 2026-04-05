using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AC.LargeAppliances.Models.Entities
{
    [Table("ProductPages")]
    public class ProductPage
    {
        [Key]
        public Guid Id { get; set; }
        public string? HeroLeftButonText { get; set; }
        public string? HeroLeftTitle { get; set; }
        public string? HeroLeftDescription { get; set; }
        public string? HeroRightImageUrl { get; set; }
    }
}
