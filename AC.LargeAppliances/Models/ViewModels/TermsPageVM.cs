using AC.LargeAppliances.Models.Entities;

namespace AC.LargeAppliances.Models.ViewModels
{
    public class TermsPageVM
    {
        public Term? Term { get; set; } = new Term();
        public Discount? Discount { get; set; }
        public IEnumerable<CardItem> CardItems { get; set; } = new List<CardItem>();

    }
}
