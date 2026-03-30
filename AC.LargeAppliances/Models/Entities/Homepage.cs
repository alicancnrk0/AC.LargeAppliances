using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AC.LargeAppliances.Models.Entities
{
    [Table("Homepages")]
    public class Homepage
    {
        [Key]
        public Guid Id { get; set; }

        // Hero 1 
        public string? HeroSubTitle { get; set; }
        public string? HeroTitle { get; set; }
        public string? HeroValues { get; set; }
        public string? HeroLeftButtonTitle { get; set; }
        public string? HeroLefButtonUrl { get; set; }
        public string? HeroRightButtonTitle { get; set; }
        public string? HeroRightButtonUrl { get; set; }


        // Mavi Turuncu yeşil kartları

        public string? BlueTitle { get; set; }
        public string? BlueSubTitle { get; set; }
        public string? BlueValues { get; set; }

        public string? OrangeTitle { get; set; }
        public string? OrangeSubTitle { get; set; }
        public string? OrangeValues { get; set; }

        public string? GreenTitle { get; set; }
        public string? GreenSubTitle { get; set; }
        public string? GreenValues { get; set; }


    }
}
