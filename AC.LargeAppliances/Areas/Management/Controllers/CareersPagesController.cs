using AC.LargeAppliances.Models;
using AC.LargeAppliances.Models.Entities;
using AC.LargeAppliances.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AC.LargeAppliances.Areas.Management.Controllers
{
    [Area("Management")]
    public class CareersPagesController : Controller
    {
        private readonly EcomDbContext _context;
        private readonly ILogger<EcomDbContext> _logger;
        private readonly IWebHostEnvironment _env;

        public CareersPagesController(EcomDbContext context, ILogger<EcomDbContext> logger, IWebHostEnvironment env)
        {
            _context = context;
            _logger = logger;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context.Careers.AsNoTracking().FirstOrDefaultAsync();
            return View(model);
        }

        public IActionResult Create()
        {
            _logger.LogInformation("CareersPagesController:Create Sayfası Açıldı");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Career model, IFormFile? img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                    model.Img = await FileUploader.UploadAsync(_env, img);

                model.Id = Guid.NewGuid();
                await _context.Careers.AddAsync(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("CareersPagesController:Create Yeni Kariyer Eklendi");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            _logger.LogInformation("CareersPagesController:Edit Sayfası Açıldı");

            var model = await _context.Careers.FirstOrDefaultAsync(c => c.Id == id);

            if (model == null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Career model, IFormFile? img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    await FileUploader.DeleteAsync(_env, model.Img);
                    model.Img = await FileUploader.UploadAsync(_env, img);
                }

                _context.Careers.Update(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("CareersPagesController:Edit Kariyer Güncellendi");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _context.Careers.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
                return Json(new { message = "Kariyer bulunamadı.", status = false });

            await FileUploader.DeleteAsync(_env, model.Img);
            _context.Careers.Remove(model);
            await _context.SaveChangesAsync();
            _logger.LogInformation("CareersPagesController:Delete Kariyer Silindi");

            return Json(new { message = "Kariyer silindi.", status = true });
        }
    }
}