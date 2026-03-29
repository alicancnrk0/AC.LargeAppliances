using AC.LargeAppliances.Models;
using AC.LargeAppliances.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AC.LargeAppliances.Areas.Management.Controllers
{
    [Area("Management")]
    public class DiscountsController : Controller
    {

        private readonly EcomDbContext _context;
        private readonly ILogger<EcomDbContext> _logger;



        public DiscountsController(EcomDbContext context, ILogger<EcomDbContext> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("DiscountController:Index Sayfası Açıldı");

            var model = await _context.Discounts.AsNoTracking().FirstOrDefaultAsync();


            return View(model);
        }

        public IActionResult Create()
        {
            _logger.LogInformation("DiscountController:Create Sayfası Açıldı");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Discount model)
        {
            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid();
                await _context.Discounts.AddAsync(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("DiscountController:Create Sayfası Düzenlendi");

                return RedirectToAction(nameof(Index));

            }

            return View(model);
        }


        public async Task<IActionResult> Edit()
        {
            var model = await _context.Discounts.FirstOrDefaultAsync();

            _logger.LogInformation("DiscountController:Edit Sayfası Açıldı");


            if (model == null) 
                return RedirectToAction(nameof(Index)); 

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Discount model)
        {
            if (ModelState.IsValid)
            {
                _context.Discounts.Update(model);
                await _context.SaveChangesAsync();
                _logger.LogInformation("DiscountController:Edit Sayfası Düzenlendi");
                return RedirectToAction(nameof(Index));
            }
            return View(model);

        }


    }



}
