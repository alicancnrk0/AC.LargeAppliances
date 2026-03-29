using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AC.LargeAppliances.Models.Entities
{
    [Table("Discounts")]
    public class Discount
    {
        [Key]
        public Guid Id {  get; set; }
        public string? Title { get; set; }
        public string? DiscountCount { get; set; }
        public string? TitleSpan { get; set; }
        public string? Description { get; set; }
        public string? SignButton { get; set; }


    }
}
