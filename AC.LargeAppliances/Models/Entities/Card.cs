using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AC.LargeAppliances.Models.Entities
{
    [Table("Cards")]
    public class Card
    {
        [Key]
        public Guid Id { get; set; }

        public string? CardIcon1Class { get; set; }
        public string? CardIcon1Tittle { get; set; }
        public string? CardIcon1Description { get; set; }

        public string? CardIcon2Class { get; set; }
        public string? CardIcon2Tittle { get; set; }
        public string? CardIcon2Description { get; set; }

        public string? CardIcon3Class { get; set; }
        public string? CardIcon3Tittle { get; set; }
        public string? CardIcon3Description { get; set; }

        public string? CardIcon4Class { get; set; }
        public string? CardIcon4Tittle { get; set; }
        public string? CardIcon4Description { get; set; }

        public string? CardIcon5Class { get; set; }
        public string? CardIcon5Tittle { get; set; }
        public string? CardIcon5Description { get; set; }


    }
}
