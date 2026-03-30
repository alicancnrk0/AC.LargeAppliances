using AC.LargeAppliances.Models;
using AC.LargeAppliances.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AC.LargeAppliances.Areas.Management.Controllers
{
    [Area("Management")]
    public class StoresController : Controller
    {
        private readonly EcomDbContext _context;
        private readonly ILogger<EcomDbContext> _logger;

        public StoresController(EcomDbContext context, ILogger<EcomDbContext> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("StoresController:Index Sayfası Açıldı");

            var model = await _context.Stores
                .AsNoTracking()
                .OrderBy(s => s.SortOrder)
                .ToListAsync();

            return View(model);
        }

        public IActionResult Create()
        {
            _logger.LogInformation("StoresController:Create Sayfası Açıldı");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Store model)
        {
            if (ModelState.IsValid)
            {
                var exists = await _context.Stores
                    .AnyAsync(s => s.SortOrder == model.SortOrder);

                if (exists)
                {
                    ModelState.AddModelError("SortOrder", "Bu sıra numarası zaten kullanılıyor.");
                    return View(model);
                }

                model.Id = Guid.NewGuid();
                await _context.Stores.AddAsync(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("StoresController:Create Yeni Mağaza Eklendi");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            _logger.LogInformation("StoresController:Edit Sayfası Açıldı");

            var model = await _context.Stores.FirstOrDefaultAsync(s => s.Id == id);

            if (model == null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Store model)
        {
            if (ModelState.IsValid)
            {
                var exists = await _context.Stores
                    .AnyAsync(s => s.SortOrder == model.SortOrder && s.Id != model.Id);

                if (exists)
                {
                    ModelState.AddModelError("SortOrder", "Bu sıra numarası zaten kullanılıyor.");
                    return View(model);
                }

                _context.Stores.Update(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("StoresController:Edit Mağaza Güncellendi");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _context.Stores.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
                return Json(new { message = "Mağaza bulunamadı.", status = false });

            _context.Stores.Remove(model);
            await _context.SaveChangesAsync();
            _logger.LogInformation("StoresController:Delete Mağaza Silindi");

            return Json(new { message = "Mağaza silindi.", status = true });
        }

    }
}
