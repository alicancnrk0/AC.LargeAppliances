using AC.LargeAppliances.Models;
using AC.LargeAppliances.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AC.LargeAppliances.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly EcomDbContext _context;
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(EcomDbContext context, ILogger<DashboardController> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("DashboardController:Index Sayfası Açıldı");

            DashboardVM vm = new DashboardVM();

            vm.TotalProducts = await _context.Products.CountAsync();
            vm.TotalVendors = await _context.Vendors.CountAsync();
            vm.TotalContactRequests = await _context.ContactRequests.CountAsync();
            vm.UnreadContactRequests = await _context.ContactRequests.CountAsync(x => !x.IsReaded);
            vm.TotalDiscountRequests = await _context.DiscountRequests.CountAsync();
            vm.UnreadDiscountRequests = await _context.DiscountRequests.CountAsync(x => !x.IsReaded);
            vm.TotalSponsors = await _context.Sponsors.CountAsync();
            vm.TotalStores = await _context.Stores.CountAsync();

            return View(vm);
        }
    }
}
