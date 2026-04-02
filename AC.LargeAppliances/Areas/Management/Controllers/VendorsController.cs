using AC.LargeAppliances.Models;
using AC.LargeAppliances.Models.Entities;
using AC.LargeAppliances.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AC.LargeAppliances.Areas.Management.Controllers
{
    [Area("Management")]
    public class VendorsController : Controller
    {
        private readonly EcomDbContext _context;
        private readonly ILogger<VendorsController> _logger;
        private readonly IWebHostEnvironment _env;

        public VendorsController(EcomDbContext context, ILogger<VendorsController> logger, IWebHostEnvironment env)
        {
            _context = context;
            _logger = logger;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("VendorsController:Index Sayfası Açıldı");

            var model = await _context.Vendors.AsNoTracking().ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            _logger.LogInformation("VendorsController:Detail Sayfası Açıldı");

            var model = await _context.Vendors.AsNoTracking().FirstOrDefaultAsync(v => v.Id == id);

            if (model == null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        public IActionResult Create()
        {
            _logger.LogInformation("VendorsController:Create Sayfası Açıldı");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendor model, IFormFile? img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                    model.Img = await FileUploader.UploadAsync(_env, img);

                model.Id = Guid.NewGuid();
                await _context.Vendors.AddAsync(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("VendorsController:Create Yeni Vendor Eklendi");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            _logger.LogInformation("VendorsController:Edit Sayfası Açıldı");

            var model = await _context.Vendors.FirstOrDefaultAsync(v => v.Id == id);

            if (model == null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Vendor model, IFormFile? img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    await FileUploader.DeleteAsync(_env, model.Img);
                    model.Img = await FileUploader.UploadAsync(_env, img);
                }

                _context.Vendors.Update(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("VendorsController:Edit Vendor Güncellendi");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _context.Vendors.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
                return Json(new { message = "Vendor bulunamadı.", status = false });

            await FileUploader.DeleteAsync(_env, model.Img);
            _context.Vendors.Remove(model);
            await _context.SaveChangesAsync();
            _logger.LogInformation("VendorsController:Delete Vendor Silindi");

            return Json(new { message = "Vendor silindi.", status = true });
        }
    }
}