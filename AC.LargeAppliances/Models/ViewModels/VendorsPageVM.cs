using AC.LargeAppliances.Models.Entities;

namespace AC.LargeAppliances.Models.ViewModels
{
    public class VendorsPageVM
    {
        public VendorPage? VendorPage = new VendorPage();
        public IEnumerable<Vendor> Vendors { get; set; } = new List<Vendor>();
        public Discount? Discount { get; set; }
        public IEnumerable<CardItem> CardItems { get; set; } = new List<CardItem>();

    }
}
