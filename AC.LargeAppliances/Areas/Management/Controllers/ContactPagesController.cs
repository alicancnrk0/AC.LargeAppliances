using AC.LargeAppliances.Models;
using AC.LargeAppliances.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AC.LargeAppliances.Areas.Management.Controllers
{
    public class ContactPagesController : Controller
    {
        private readonly EcomDbContext _context;
        private readonly ILogger<EcomDbContext> _logger;

        public ContactPagesController(EcomDbContext context, ILogger<EcomDbContext> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("ContactpagesController:Index Sayfası Açıldı");

            var model = await _context.Contactpages.AsNoTracking().FirstOrDefaultAsync();

            return View(model);
        }

        public IActionResult Create()
        {
            _logger.LogInformation("ContactpagesController:Create Sayfası Açıldı");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contactpage model)
        {
            if (ModelState.IsValid)
            {
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
        public async Task<IActionResult> Edit(Contactpage model)
        {
            if (ModelState.IsValid)
            {
                _context.Contactpages.Update(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("ContactpagesController:Edit İletişim Sayfası Güncellendi");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

    }
}
