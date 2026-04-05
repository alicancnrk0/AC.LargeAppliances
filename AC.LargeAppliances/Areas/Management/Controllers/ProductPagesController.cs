using AC.LargeAppliances.Models;
using AC.LargeAppliances.Models.Entities;
using AC.LargeAppliances.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AC.LargeAppliances.Areas.Management.Controllers
{
    [Area("Management")]
    public class ProductPagesController : Controller
    {
        private readonly EcomDbContext _context;
        private readonly ILogger<ProductPagesController> _logger;
        private readonly IWebHostEnvironment _env;

        public ProductPagesController(EcomDbContext context, ILogger<ProductPagesController> logger, IWebHostEnvironment env)
        {
            _context = context;
            _logger = logger;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("ProductPagesController:Index Sayfası Açıldı");

            var model = await _context.ProductPages.AsNoTracking().FirstOrDefaultAsync();

            return View(model);
        }

        public IActionResult Create()
        {
            _logger.LogInformation("ProductPagesController:Create Sayfası Açıldı");

            var exists = _context.ProductPages.Any();

            if (exists)
                return RedirectToAction(nameof(Index));

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductPage model,  IFormFile? heroRightImg)
        {
            if (ModelState.IsValid)
            {

                if (heroRightImg != null)
                    model.HeroRightImageUrl = await FileUploader.UploadAsync(_env, heroRightImg);

                model.Id = Guid.NewGuid();
                await _context.ProductPages.AddAsync(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("ProductPagesController:Create Ürün Sayfası Oluşturuldu");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit()
        {
            _logger.LogInformation("ProductPagesController:Edit Sayfası Açıldı");

            var model = await _context.ProductPages.FirstOrDefaultAsync();

            if (model == null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductPage model, IFormFile? heroRightImg)
        {
            if (ModelState.IsValid)
            {
                if (heroRightImg != null)
                {
                    await FileUploader.DeleteAsync(_env, model.HeroRightImageUrl);
                    model.HeroRightImageUrl = await FileUploader.UploadAsync(_env, heroRightImg);
                }

                _context.ProductPages.Update(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("ProductPagesController:Edit Ürün Sayfası Güncellendi");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}