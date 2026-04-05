using AC.LargeAppliances.Models.Entities;

namespace AC.LargeAppliances.Models.ViewModels
{
    public class HomePageVM
    {
        public HomePage? HomePage { get; set; } = new HomePage();
        public IEnumerable<Product> MostDiscountedProducts { get; set; } = new List<Product>();

        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public Discount? Discount { get; set; }
        public IEnumerable<CardItem> CardItems { get; set; } = new List<CardItem>();
        public IEnumerable<Sponsor> Sponsors { get; set; } = new List<Sponsor>();

    }
}
