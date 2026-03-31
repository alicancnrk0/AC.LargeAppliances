using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AC.LargeAppliances.Models.Entities
{
    [Table("Contactpages")]
    public class Contactpage
    {
        [Key]
        public Guid Id { get; set; }
        public string? Tittle { get; set; }
        public string? Description { get; set; }
        public string? Maps { get; set; }
        public string? ButtonTitle { get; set; }

        public string? StoresTittle { get; set; }
        public string? StoresDescription { get; set; }


        public string? BottomTitle { get; set; }
        public string? BottomDescription { get; set; }

        public string? BottomChatImagePath { get; set; }
        public string? BottomChatTitle { get; set; }
        public string? BottomChatDescription { get; set; }
        public string? BottomChatMail { get; set; }

        public string? BottomPhoneImagePath { get; set; }
        public string? BottomPhoneTitle { get; set; }
        public string? BottomPhoneDescription { get; set; }
        public string? BottomPhoneNumber { get; set; }

        public string? BottomMapImagePath { get; set; }
        public string? BottomMapTitle { get; set; }
        public string? BottomMapDescription { get; set; }
        public string? BottomMapAddress { get; set; }

    }
}
