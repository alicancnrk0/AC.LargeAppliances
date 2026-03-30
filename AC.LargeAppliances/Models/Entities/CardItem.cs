using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AC.LargeAppliances.Models.Entities
{
    [Table("CardItems")]
    public class CardItem
    {
        [Key]
        public Guid Id { get; set; }

        public string? IconClass { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int SortOrder { get; set; }


    }
}
