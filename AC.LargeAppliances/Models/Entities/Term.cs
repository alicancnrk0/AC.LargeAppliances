using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AC.LargeAppliances.Models.Entities
{
    [Table("Terms")]
    public class Term
    {
        [Key]
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Img { get; set; }
        public string? Policy { get; set; }
    }
}
