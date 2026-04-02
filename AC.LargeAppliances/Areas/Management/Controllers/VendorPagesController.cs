using AC.LargeAppliances.Models;
using AC.LargeAppliances.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AC.LargeAppliances.Areas.Management.Controllers
{
    [Area("Management")]
    public class VendorPagesController : Controller
    {
        private readonly EcomDbContext _context;
        private readonly ILogger<VendorPagesController> _logger;

        public VendorPagesController(EcomDbContext context, ILogger<VendorPagesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("VendorPagesController:Index Sayfası Açıldı");

            var model = await _context.VendorPages.AsNoTracking().FirstOrDefaultAsync();

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            _logger.LogInformation("VendorPagesController:Create Sayfası Açıldı");

            var model = await _context.VendorPages.AnyAsync();
            
            if (model)
                return RedirectToAction(nameof(Index));

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VendorPage model)
        {
            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid();
                await _context.VendorPages.AddAsync(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("VendorPagesController:Create Vendor Sayfası Oluşturuldu");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            _logger.LogInformation("VendorPagesController:Edit Sayfası Açıldı");

            var model = await _context.VendorPages.FirstOrDefaultAsync();

            if (model == null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VendorPage model)
        {
            if (ModelState.IsValid)
            {
                _context.VendorPages.Update(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("VendorPagesController:Edit Vendor Sayfası Güncellendi");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}