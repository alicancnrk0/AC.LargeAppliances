using AC.LargeAppliances.Models.Entities;

namespace AC.LargeAppliances.Models.ViewModels
{
    public class CareersPageVM
    {
        public Career? Career { get; set; } = new Career();
        public Discount? Discount { get; set; }
        public IEnumerable<CardItem> CardItems { get; set; } = new List<CardItem>();

    }
}
