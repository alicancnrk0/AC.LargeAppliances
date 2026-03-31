using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AC.LargeAppliances.Models.Entities
{
    [Table("DiscountRequests")]
    public class DiscountRequest
    {
        [Key]
        public Guid Id { get; set; }
        public string? MailAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsReaded { get; set; }
    }
}
