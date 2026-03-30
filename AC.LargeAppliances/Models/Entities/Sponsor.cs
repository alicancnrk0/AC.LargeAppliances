using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AC.LargeAppliances.Models.Entities
{
    [Table("Sponsors")]
    public class Sponsor
    {
        [Key]
        public Guid Id { get; set; }
        public string?  Tittle { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageAlt { get; set; }


    }
}
