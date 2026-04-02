using AC.LargeAppliances.Models;
using AC.LargeAppliances.Models.Entities;
using AC.LargeAppliances.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AC.LargeAppliances.Areas.Management.Controllers
{
    [Area("Management")]
    public class ContactPagesController : Controller
    {
        private readonly EcomDbContext _context;
        private readonly ILogger<ContactPagesController> _logger;
        private readonly IWebHostEnvironment _env;

        public ContactPagesController(EcomDbContext context, ILogger<ContactPagesController> logger, IWebHostEnvironment env)
        {
            _context = context;
            _logger = logger;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("ContactpagesController:Index Sayfası Açıldı");

            var model = await _context.Contactpages.AsNoTracking().FirstOrDefaultAsync();

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            _logger.LogInformation("ContactpagesController:Create Sayfası Açıldı");

            var model = await _context.Contactpages.AnyAsync();

            if (model)
                return RedirectToAction(nameof(Index));

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contactpage model, IFormFile? chatImg, IFormFile? phoneImg, IFormFile? mapImg)
        {
            if (ModelState.IsValid)
            {
                if (chatImg != null)
                    model.BottomChatImagePath = await FileUploader.UploadAsync(_env, chatImg);

                if (phoneImg != null)
                    model.BottomPhoneImagePath = await FileUploader.UploadAsync(_env, phoneImg);

                if (mapImg != null)
                    model.BottomMapImagePath = await FileUploader.UploadAsync(_env, mapImg);

                model.Id = Guid.NewGuid();
                await _context.Contactpages.AddAsync(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("ContactpagesController:Create İletişim Sayfası Oluşturuldu");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            _logger.LogInformation("ContactpagesController:Edit Sayfası Açıldı");

            var model = await _context.Contactpages.FirstOrDefaultAsync();

            if (model == null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Contactpage model, IFormFile? chatImg, IFormFile? phoneImg, IFormFile? mapImg)
        {
            if (ModelState.IsValid)
            {
                if (chatImg != null)
                {
                    await FileUploader.DeleteAsync(_env, model.BottomChatImagePath);
                    model.BottomChatImagePath = await FileUploader.UploadAsync(_env, chatImg);
                }

                if (phoneImg != null)
                {
                    await FileUploader.DeleteAsync(_env, model.BottomPhoneImagePath);
                    model.BottomPhoneImagePath = await FileUploader.UploadAsync(_env, phoneImg);
                }

                if (mapImg != null)
                {
                    await FileUploader.DeleteAsync(_env, model.BottomMapImagePath);
                    model.BottomMapImagePath = await FileUploader.UploadAsync(_env, mapImg);
                }

                _context.Contactpages.Update(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("ContactpagesController:Edit İletişim Sayfası Güncellendi");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}