using AC.LargeAppliances.Models;
using AC.LargeAppliances.Models.Entities;
using AC.LargeAppliances.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AC.LargeAppliances.Areas.Management.Controllers
{
    [Area("Management")]
    public class CardItemsController : Controller
    {
        private readonly EcomDbContext _context;
        private readonly ILogger<EcomDbContext> _logger;
        private readonly IWebHostEnvironment _env;

        public CardItemsController(EcomDbContext context, ILogger<EcomDbContext> logger, IWebHostEnvironment env)
        {
            _context = context;
            _logger = logger;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("CardItemsController:Index Sayfası Açıldı");

            var model = await _context.CardItems
                .AsNoTracking()
                .OrderBy(c => c.SortOrder)
                .ToListAsync();

            return View(model);
        }

        public IActionResult Create()
        {
            _logger.LogInformation("CardItemsController:Create Sayfası Açıldı");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CardItem model, IFormFile? img)
        {
            if (ModelState.IsValid)
            {
                var exists = await _context.CardItems
                    .AnyAsync(c => c.SortOrder == model.SortOrder);

                if (exists)
                {
                    ModelState.AddModelError("SortOrder", "Bu sıra numarası zaten kullanılıyor.");
                    return View(model);
                }

                if (img != null)
                    model.IconImagePath = await FileUploader.UploadAsync(_env, img);

                model.Id = Guid.NewGuid();
                await _context.CardItems.AddAsync(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("CardItemsController:Create Yeni Kart Eklendi");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            _logger.LogInformation("CardItemsController:Edit Sayfası Açıldı");

            var model = await _context.CardItems.FirstOrDefaultAsync(c => c.Id == id);

            if (model == null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CardItem model, IFormFile? img)
        {
            if (ModelState.IsValid)
            {
                var exists = await _context.CardItems
                    .AnyAsync(c => c.SortOrder == model.SortOrder && c.Id != model.Id);

                if (exists)
                {
                    ModelState.AddModelError("SortOrder", "Bu sıra numarası zaten kullanılıyor.");
                    return View(model);
                }

                if (img != null)
                {
                    await FileUploader.DeleteAsync(_env, model.IconImagePath);
                    model.IconImagePath = await FileUploader.UploadAsync(_env, img);
                }

                _context.CardItems.Update(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("CardItemsController:Edit Kart Güncellendi");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _context.CardItems.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
                return Json(new { message = "Kart bulunamadı.", status = false });

            await FileUploader.DeleteAsync(_env, model.IconImagePath);
            _context.CardItems.Remove(model);
            await _context.SaveChangesAsync();
            _logger.LogInformation("CardItemsController:Delete Kart Silindi");

            return Json(new { message = "Kart silindi.", status = true });
        }
    }
}