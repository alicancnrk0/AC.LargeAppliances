using AC.LargeAppliances.Models;
using AC.LargeAppliances.Models.Entities;
using AC.LargeAppliances.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AC.LargeAppliances.Areas.Management.Controllers
{
    [Area("Management")]
    public class AboutPagesController : Controller
    {
        private readonly EcomDbContext _context;
        private readonly ILogger<EcomDbContext> _logger;
        private readonly IWebHostEnvironment _env;

        public AboutPagesController(EcomDbContext context, ILogger<EcomDbContext> logger, IWebHostEnvironment env)
        {
            _context = context;
            _logger = logger;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("AboutPagesController:Index Sayfası Açıldı");

            var model = await _context.AboutPages.AsNoTracking().FirstOrDefaultAsync();

            return View(model);
        }

        public IActionResult Create()
        {
            _logger.LogInformation("AboutPagesController:Create Sayfası Açıldı");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AboutPage model, IFormFile? mainImg)
        {
            if (ModelState.IsValid)
            {
                if (mainImg != null)
                    model.ImageUrl = await FileUploader.UploadAsync(_env, mainImg);

                model.Id = Guid.NewGuid();
                await _context.AboutPages.AddAsync(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("AboutPagesController:Create Hakkımızda Sayfası Oluşturuldu");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            _logger.LogInformation("AboutPagesController:Edit Sayfası Açıldı");

            var model = await _context.AboutPages.FirstOrDefaultAsync();

            if (model == null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AboutPage model, IFormFile? mainImg)
        {
            if (ModelState.IsValid)
            {
                if (mainImg != null)
                {
                    await FileUploader.DeleteAsync(_env, model.ImageUrl);
                    model.ImageUrl = await FileUploader.UploadAsync(_env, mainImg);
                }

                _context.AboutPages.Update(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("AboutPagesController:Edit Hakkımızda Sayfası Güncellendi");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}