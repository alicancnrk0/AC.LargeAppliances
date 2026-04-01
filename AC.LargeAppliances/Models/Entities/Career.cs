using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AC.LargeAppliances.Models.Entities
{
    [Table("Careers")]
    public class Career
    {
        [Key]
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Img { get; set; }
    }
}
