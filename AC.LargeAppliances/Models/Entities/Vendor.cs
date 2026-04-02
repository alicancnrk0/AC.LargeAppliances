using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AC.LargeAppliances.Models.Entities
{
    [Table("Vendors")]
    public class Vendor
    {
        [Key]
        public Guid Id { get; set; }
        public string? Img { get; set; }
        public string? Name { get; set; }
        public int? ReviewCount { get; set; }
        public string? YearOfFoundation { get; set; }
        public string? ProductTitle { get; set; }
        public int? ProductCount { get; set; }
        public string? MapIconClass { get; set; }
        public string? MapAddress { get; set; }
        public string? PhoneIconClass { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
