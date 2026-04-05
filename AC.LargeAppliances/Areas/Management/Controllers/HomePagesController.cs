using AC.LargeAppliances.Models;
using AC.LargeAppliances.Models.Entities;
using AC.LargeAppliances.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AC.LargeAppliances.Areas.Management.Controllers
{
    [Area("Management")]
    public class HomePagesController : Controller
    {
        private readonly EcomDbContext _context;
        private readonly ILogger<HomePagesController> _logger;

        public HomePagesController(EcomDbContext context, ILogger<HomePagesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("HomePagesController:Index Sayfası Açıldı");

            var model = await _context.HomePages.AsNoTracking().FirstOrDefaultAsync();

            return View(model);
        }

        public IActionResult Create()
        {
            _logger.LogInformation("HomePagesController:Create Sayfası Açıldı");

            var exists = _context.HomePages.Any();

            if (exists)
                return RedirectToAction(nameof(Index));

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HomePage model)
        {
            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid();
                await _context.HomePages.AddAsync(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("HomePagesController:Create Ana Sayfa Oluşturuldu");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            _logger.LogInformation("HomePagesController:Edit Sayfası Açıldı");

            var model = await _context.HomePages.FirstOrDefaultAsync();

            if (model == null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HomePage model)
        {
            if (ModelState.IsValid)
            {
                _context.HomePages.Update(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("HomePagesController:Edit Ana Sayfa Güncellendi");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}