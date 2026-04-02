using AC.LargeAppliances.Models;
using AC.LargeAppliances.Models.Entities;
using AC.LargeAppliances.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AC.LargeAppliances.Areas.Management.Controllers
{
    [Area("Management")]
    public class SponsorsController : Controller
    {
        private readonly EcomDbContext _context;
        private readonly ILogger<SponsorsController> _logger;
        private readonly IWebHostEnvironment _env;

        public SponsorsController(EcomDbContext context, ILogger<SponsorsController> logger, IWebHostEnvironment env)
        {
            _context = context;
            _logger = logger;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("SponsorsController:Index Sayfası Açıldı");

            var model = await _context.Sponsors
                .AsNoTracking()
                .ToListAsync();

            return View(model);
        }

        public IActionResult Create()
        {
            _logger.LogInformation("SponsorsController:Create Sayfası Açıldı");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sponsor model, IFormFile? img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                    model.ImageUrl = await FileUploader.UploadAsync(_env, img);

                model.Id = Guid.NewGuid();
                await _context.Sponsors.AddAsync(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("SponsorsController:Create Yeni Sponsor Eklendi");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            _logger.LogInformation("SponsorsController:Edit Sayfası Açıldı");

            var model = await _context.Sponsors.FirstOrDefaultAsync(s => s.Id == id);

            if (model == null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Sponsor model, IFormFile? img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    await FileUploader.DeleteAsync(_env, model.ImageUrl);
                    model.ImageUrl = await FileUploader.UploadAsync(_env, img);
                }

                _context.Sponsors.Update(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("SponsorsController:Edit Sponsor Güncellendi");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _context.Sponsors.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
                return Json(new { message = "Sponsor bulunamadı.", status = false });

            await FileUploader.DeleteAsync(_env, model.ImageUrl);
            _context.Sponsors.Remove(model);
            await _context.SaveChangesAsync();
            _logger.LogInformation("SponsorsController:Delete Sponsor Silindi");

            return Json(new { message = "Sponsor silindi.", status = true });
        }


    }
}