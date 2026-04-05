using AC.LargeAppliances.Models;
using AC.LargeAppliances.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AC.LargeAppliances.Areas.Management.Controllers
{
    [Area("Management")]
    public class ContactRequestsController : Controller
    {
        private readonly EcomDbContext _context;
        private readonly ILogger<ContactRequestsController> _logger;

        public ContactRequestsController(EcomDbContext context, ILogger<ContactRequestsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("ContactRequestsController:Index Sayfası Açıldı");

            var model = await _context.ContactRequests
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            var model = await _context.ContactRequests.FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ToggleRead(Guid id)
        {
            var model = await _context.ContactRequests.FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
                return Json(new { message = "İstek bulunamadı.", status = false });

            model.IsReaded = !model.IsReaded;
            _context.ContactRequests.Update(model);
            await _context.SaveChangesAsync();

            return Json(new { message = "Güncellendi.", status = true, isReaded = model.IsReaded });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _context.ContactRequests.FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
                return Json(new { message = "İstek bulunamadı.", status = false });

            _context.ContactRequests.Remove(model);
            await _context.SaveChangesAsync();
            _logger.LogInformation("ContactRequestsController:Delete İletişim İsteği Silindi");

            return Json(new { message = "İstek silindi.", status = true });
        }
    }
}