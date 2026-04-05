using AC.LargeAppliances.Models.Entities;

namespace AC.LargeAppliances.Models.ViewModels
{
    public class ProductPageVM
    {
        public ProductPage? ProductPage { get; set; } = new ProductPage();

        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public Discount? Discount { get; set; }
        public IEnumerable<CardItem> CardItems { get; set; } = new List<CardItem>();
    }
}
