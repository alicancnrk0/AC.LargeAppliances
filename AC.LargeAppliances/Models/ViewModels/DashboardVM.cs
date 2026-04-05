namespace AC.LargeAppliances.Models.ViewModels
{
    public class DashboardVM
    {
        public int TotalProducts { get; set; }
        public int TotalVendors { get; set; }
        public int TotalContactRequests { get; set; }
        public int UnreadContactRequests { get; set; }
        public int TotalDiscountRequests { get; set; }
        public int UnreadDiscountRequests { get; set; }
        public int TotalSponsors { get; set; }
        public int TotalStores { get; set; }
    }
}
