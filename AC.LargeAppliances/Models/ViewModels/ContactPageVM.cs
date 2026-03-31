using AC.LargeAppliances.Models.Entities;

namespace AC.LargeAppliances.Models.ViewModels
{
    public class ContactPageVM
    {
        public Contactpage? Contactpage { get; set; } = new Contactpage();
        public Discount? Discount { get; set; }
        public IEnumerable<CardItem> CardItems { get; set; } = new List<CardItem>();
        public IEnumerable<Store> Stores { get; set; } = new List<Store>();
    }
}
