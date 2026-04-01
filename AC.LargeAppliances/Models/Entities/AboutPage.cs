using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AC.LargeAppliances.Models.Entities
{
    [Table("AboutPages")]
    public class AboutPage
    {
        [Key]
        public Guid Id { get; set; }

        public string? SubTitle { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public string? Value1IconClass { get; set; }
        public string? Value1Title { get; set; }

        public string? Value2IconClass { get; set; }
        public string? Value2Title { get; set; }

        public string? Value3IconClass { get; set; }
        public string? Value3Title { get; set; }

        public string? Value4IconClass { get; set; }
        public string? Value4Title { get; set; }


        public string? Features1Title { get; set; }
        public string? Features1Description{ get; set; }

        public string? Features2Title { get; set; }
        public string? Features2Description{ get; set; }

        public string? Features3Title { get; set; }
        public string? Features3Description{ get; set; }

        public string? Features4Title { get; set; }
        public string? Features4Description{ get; set; }


        public string? PartnerTitle { get; set; }
        public string? PartnerDescription { get; set; }

        public string? StoresTitle { get; set; }
        public string? StoresDescription { get; set; }

    }


}
