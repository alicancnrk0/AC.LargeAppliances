using AC.LargeAppliances.Models;
using AC.LargeAppliances.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AC.LargeAppliances.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize]
    public class DiscountRequestsController : Controller
    {
        private readonly EcomDbContext _context;
        private readonly ILogger<DiscountRequestsController> _logger;

        public DiscountRequestsController(EcomDbContext context, ILogger<DiscountRequestsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("DiscountRequestsController:Index Sayfası Açıldı");

            var model = await _context.DiscountRequests
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ToggleRead(Guid id)
        {
            var model = await _context.DiscountRequests.FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
                return Json(new { message = "İstek bulunamadı.", status = false });

            model.IsReaded = !model.IsReaded;
            _context.DiscountRequests.Update(model);
            await _context.SaveChangesAsync();

            return Json(new { message = "Güncellendi.", status = true, isReaded = model.IsReaded });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _context.DiscountRequests.FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
                return Json(new { message = "İstek bulunamadı.", status = false });

            _context.DiscountRequests.Remove(model);
            await _context.SaveChangesAsync();
            _logger.LogInformation("DiscountRequestsController:Delete İndirim İsteği Silindi");

            return Json(new { message = "İstek silindi.", status = true });
        }
    }
}