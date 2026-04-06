using AC.LargeAppliances.Models;
using AC.LargeAppliances.Models.Entities;
using AC.LargeAppliances.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AC.LargeAppliances.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly EcomDbContext _context;
        private readonly ILogger<ProductsController> _logger;
        private readonly IWebHostEnvironment _env;

        public ProductsController(EcomDbContext context, ILogger<ProductsController> logger, IWebHostEnvironment env)
        {
            _context = context;
            _logger = logger;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("ProductsController:Index Sayfası Açıldı");

            var model = await _context.Products
                .AsNoTracking()
                .Include(x => x.Vendor)
                .ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            _logger.LogInformation("ProductsController:Create Sayfası Açıldı");

            ViewBag.Vendors = await _context.Vendors.AsNoTracking().ToListAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product model)
        {
            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid();
                await _context.Products.AddAsync(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("ProductsController:Create Yeni Ürün Eklendi");

                return RedirectToAction(nameof(Edit), new { id = model.Id });
            }

            ViewBag.Vendors = await _context.Vendors.AsNoTracking().ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            _logger.LogInformation("ProductsController:Edit Sayfası Açıldı");

            var model = await _context.Products
                .Include(x => x.Images.OrderBy(c => c.SortOrder))
                .Include(x => x.Features.OrderBy(c => c.SortOrder))
                .Include(x => x.AdditionalInfos)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
                return RedirectToAction(nameof(Index));

            ViewBag.Vendors = await _context.Vendors.AsNoTracking().ToListAsync();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("ProductsController:Edit Ürün Güncellendi");

                return RedirectToAction(nameof(Edit), new { id = model.Id });
            }

            ViewBag.Vendors = await _context.Vendors.AsNoTracking().ToListAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await _context.Products
                .Include(p => p.Images)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
                return Json(new { message = "Ürün bulunamadı.", status = false });

            foreach (var image in model.Images)
                await FileUploader.DeleteAsync(_env, image.ImageUrl);

            _context.Products.Remove(model);
            await _context.SaveChangesAsync();
            _logger.LogInformation("ProductsController:Delete Ürün Silindi");

            return Json(new { message = "Ürün silindi.", status = true });
        }

        // ---- IMAGE ----

        [HttpPost]
        public async Task<IActionResult> AddImage(Guid productId, IFormFile img)
        {
            if (img == null)
                return Json(new { message = "Resim seçilmedi.", status = false });

            var imageUrl = await FileUploader.UploadAsync(_env, img);

            var lastOrder = await _context.ProductImages
                .Where(x => x.ProductId == productId)
                .MaxAsync(x => (int?)x.SortOrder) ?? 0;

            var image = new ProductImage
            {
                Id = Guid.NewGuid(),
                ProductId = productId,
                ImageUrl = imageUrl,
                SortOrder = lastOrder + 1
            };

            await _context.ProductImages.AddAsync(image);
            await _context.SaveChangesAsync();

            return Json(new { message = "Resim eklendi.", status = true, imageUrl, imageId = image.Id });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteImage(Guid id)
        {
            var image = await _context.ProductImages.FirstOrDefaultAsync(x => x.Id == id);

            if (image == null)
                return Json(new { message = "Resim bulunamadı.", status = false });

            await FileUploader.DeleteAsync(_env, image.ImageUrl);
            _context.ProductImages.Remove(image);
            await _context.SaveChangesAsync();

            return Json(new { message = "Resim silindi.", status = true });
        }

        // ---- FEATURE ----

        [HttpPost]
        public async Task<IActionResult> AddFeature(Guid productId, string key, string value)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
                return Json(new { message = "Alan ve değer boş olamaz.", status = false });

            var lastOrder = await _context.ProductFeatures
                .Where(x => x.ProductId == productId)
                .MaxAsync(x => (int?)x.SortOrder) ?? 0;

            var feature = new ProductFeature
            {
                Id = Guid.NewGuid(),
                ProductId = productId,
                Key = key,
                Value = value,
                SortOrder = lastOrder + 1
            };

            await _context.ProductFeatures.AddAsync(feature);
            await _context.SaveChangesAsync();

            return Json(new { message = "Özellik eklendi.", status = true, featureId = feature.Id, key, value });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFeature(Guid id)
        {
            var feature = await _context.ProductFeatures.FirstOrDefaultAsync(x => x.Id == id);

            if (feature == null)
                return Json(new { message = "Özellik bulunamadı.", status = false });

            _context.ProductFeatures.Remove(feature);
            await _context.SaveChangesAsync();

            return Json(new { message = "Özellik silindi.", status = true });
        }

        // ---- ADDITIONAL INFO ----

        [HttpPost]
        public async Task<IActionResult> AddAdditionalInfo(Guid productId, string key, string value)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
                return Json(new { message = "Alan ve değer boş olamaz.", status = false });

            var info = new ProductAdditionalInfo
            {
                Id = Guid.NewGuid(),
                ProductId = productId,
                Key = key,
                Value = value
            };

            await _context.ProductAdditionalInfos.AddAsync(info);
            await _context.SaveChangesAsync();

            return Json(new { message = "Bilgi eklendi.", status = true, infoId = info.Id, key, value });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAdditionalInfo(Guid id)
        {
            var info = await _context.ProductAdditionalInfos.FirstOrDefaultAsync(x => x.Id == id);

            if (info == null)
                return Json(new { message = "Bilgi bulunamadı.", status = false });

            _context.ProductAdditionalInfos.Remove(info);
            await _context.SaveChangesAsync();

            return Json(new { message = "Bilgi silindi.", status = true });
        }
    }
}