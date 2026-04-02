using AC.LargeAppliances.Models;
using AC.LargeAppliances.Models.Entities;
using AC.LargeAppliances.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AC.LargeAppliances.Areas.Management.Controllers
{
    [Area("Management")]
    public class TermsPagesController : Controller
    {
        private readonly EcomDbContext _context;
        private readonly ILogger<TermsPagesController> _logger;
        private readonly IWebHostEnvironment _env;

        public TermsPagesController(EcomDbContext context, ILogger<TermsPagesController> logger, IWebHostEnvironment env)
        {
            _context = context;
            _logger = logger;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("TermsPagesController:Index Sayfası Açıldı");

            var model = await _context.Terms.AsNoTracking().FirstOrDefaultAsync();

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            _logger.LogInformation("TermsPagesController:Create Sayfası Açıldı");

            var model = await _context.Terms.AnyAsync();

            if (model)
                return RedirectToAction(nameof(Index));

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Term model, IFormFile? img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                    model.Img = await FileUploader.UploadAsync(_env, img);

                model.Id = Guid.NewGuid();
                await _context.Terms.AddAsync(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("TermsPagesController:Create Kullanım Koşulları Sayfası Oluşturuldu");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            _logger.LogInformation("TermsPagesController:Edit Sayfası Açıldı");

            var model = await _context.Terms.FirstOrDefaultAsync();

            if (model == null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Term model, IFormFile? img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    await FileUploader.DeleteAsync(_env, model.Img);
                    model.Img = await FileUploader.UploadAsync(_env, img);
                }

                _context.Terms.Update(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("TermsPagesController:Edit Kullanım Koşulları Sayfası Güncellendi");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}