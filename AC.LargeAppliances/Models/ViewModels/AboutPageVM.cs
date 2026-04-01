using AC.LargeAppliances.Models.Entities;

namespace AC.LargeAppliances.Models.ViewModels
{
    public class AboutPageVM
    {
        public AboutPage? AboutPage { get; set; } = new AboutPage();
        public Discount? Discount { get; set; }
        public IEnumerable<CardItem> CardItems { get; set; } = new List<CardItem>();
        public IEnumerable<Store> Stores { get; set; } = new List<Store>();
        public IEnumerable<Sponsor> Sponsors { get; set; } = new List<Sponsor>();
    }
}
