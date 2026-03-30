using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AC.LargeAppliances.Models.Entities
{
    [Table("Stores")]
    public class Store
    {
        [Key]
        public Guid Id { get; set; }

        public string? Title { get; set; }
        public string? Address { get; set; }
        public int SortOrder { get; set; } = 0;
    }
}
