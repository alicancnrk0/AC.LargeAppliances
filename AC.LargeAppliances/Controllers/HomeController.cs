using AC.LargeAppliances.Models;
using AC.LargeAppliances.Models.Entities;
using AC.LargeAppliances.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AC.LargeAppliances.Controllers
{
    public class HomeController : Controller
    {
        private readonly EcomDbContext _context;

        public HomeController(EcomDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomePageVM vm = new HomePageVM();

            vm.HomePage = await _context.HomePages
                .AsNoTracking()
                .FirstOrDefaultAsync();

            vm.MostDiscountedProducts = await _context.Products
                .AsNoTracking()
                .Include(x => x.Vendor)
                .Include(x => x.Images.OrderBy(i => i.SortOrder))
                .Where(x => x.OldPrice.HasValue && x.OldPrice > 0)
                .OrderByDescending(x => (x.OldPrice - x.Price) / x.OldPrice * 100)
                .Take(5)
                .ToListAsync();

            vm.Products = await _context.Products
                .AsNoTracking()
                .Include(x => x.Vendor)
                .Include(x => x.Images.OrderBy(x => x.SortOrder))
                .ToListAsync();

            vm.Sponsors = await _context.Sponsors
                  .AsNoTracking()
                  .Take(10)
                  .ToListAsync();

            vm.CardItems = await _context.CardItems
               .AsNoTracking()
               .OrderBy(x => x.SortOrder)
               .ToListAsync();

            vm.Discount = await _context.Discounts
               .AsNoTracking()
               .FirstOrDefaultAsync();


            return View(vm);
        }


        public async Task<IActionResult> About()
        {
            AboutPageVM vm = new AboutPageVM();

            vm.AboutPage = await _context.AboutPages
                .AsNoTracking()
                .FirstOrDefaultAsync();

            vm.Sponsors = await _context.Sponsors
                .AsNoTracking()
                .ToListAsync();

            vm.Stores = await _context.Stores
                .AsNoTracking()
                .OrderBy(x => x.SortOrder)
                .ToListAsync();

            vm.CardItems = await _context.CardItems
                .AsNoTracking()
                .OrderBy(x => x.SortOrder)
                .ToListAsync();

            vm.Discount = await _context.Discounts
               .AsNoTracking()
               .FirstOrDefaultAsync();

            return View(vm);
        }

        public async Task<IActionResult> Contact()
        {
            ContactPageVM vm = new ContactPageVM();

            vm.Contactpage = await _context.Contactpages
                .AsNoTracking()
                .FirstOrDefaultAsync();

            vm.Stores = await _context.Stores
                .AsNoTracking()
                .OrderBy(x=> x.SortOrder)
                .ToListAsync();

            vm.CardItems = await _context.CardItems
                .AsNoTracking()
                .OrderBy(x => x.SortOrder)
                .ToListAsync();

             vm.Discount = await _context.Discounts
                .AsNoTracking()
                .FirstOrDefaultAsync();

             return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(string firstName, string lastName, string email, string phone, string message)
        {
            var request = new ContactRequest
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                Message = message,
                CreatedDate = DateTime.Now,
                IsReaded = false
            };

            await _context.ContactRequests.AddAsync(request);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Contact));
        }


        public IActionResult NotFoundPage()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Subscribe(string mailAddress, string returnUrl)
        {
            if (!string.IsNullOrEmpty(mailAddress))
            {
                var request = new DiscountRequest
                {
                    Id = Guid.NewGuid(),
                    MailAddress = mailAddress,
                    CreatedDate = DateTime.Now,
                    IsReaded = false
                };

                await _context.DiscountRequests.AddAsync(request);
                await _context.SaveChangesAsync();
            }

            return Redirect(returnUrl ?? "/");
        }


        public async Task<IActionResult> Vendors(int page = 1) 
        {
            int pageSize = 12;

            VendorsPageVM vm = new VendorsPageVM();

            vm.VendorPage = await _context.VendorPages
                .AsNoTracking()
                .FirstOrDefaultAsync();

            vm.Vendors = await _context.Vendors
                .AsNoTracking()
                .OrderBy(x => x.ReviewCount)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            vm.CardItems = await _context.CardItems
                .AsNoTracking()
                .OrderBy(x => x.SortOrder)
                .ToListAsync();

            vm.Discount = await _context.Discounts
               .AsNoTracking()
               .FirstOrDefaultAsync();

            int totalVendors = await _context.Vendors.CountAsync();
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalVendors / pageSize);
            ViewBag.TotalVendors = totalVendors;

            return View(vm);
        }


        public async Task<IActionResult> Products(int page = 1 )
        {

            int pageSize = 16;

            ProductPageVM vm = new ProductPageVM();

            vm.ProductPage = await _context.ProductPages
                .AsNoTracking()
                .FirstOrDefaultAsync();

            vm.Products = await _context.Products
                .AsNoTracking()
                .Include(x => x.Vendor)
                .Include(x => x.Images.OrderBy(x => x.SortOrder))
                .ToListAsync();

            vm.CardItems = await _context.CardItems
                .AsNoTracking()
                .OrderBy(x => x.SortOrder)
                .ToListAsync();

            vm.Discount = await _context.Discounts
               .AsNoTracking()
               .FirstOrDefaultAsync();

            int totalProducts = await _context.Products.CountAsync();
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

            return View(vm);
        }


        public async Task<IActionResult> ProductView(Guid id)
        {
            ProductViewVM vm = new ProductViewVM();

            vm.Product = await _context.Products
                .AsNoTracking()
                .Include(x => x.Vendor)
                .Include(x => x.Images.OrderBy(x => x.SortOrder))
                .Include(x => x.Features.OrderBy(x => x.SortOrder))
                .Include(x => x.AdditionalInfos)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (vm.Product == null)
                return RedirectToAction(nameof(Products));

            vm.CardItems = await _context.CardItems
                .AsNoTracking()
                .OrderBy(x => x.SortOrder)
                .ToListAsync();

            vm.Discount = await _context.Discounts
               .AsNoTracking()
               .FirstOrDefaultAsync();


            return View(vm);
        }

        public async Task<IActionResult> Term()
        {

            TermsPageVM vm = new TermsPageVM();

            vm.Term = await _context.Terms
                .AsNoTracking()
                .FirstOrDefaultAsync();

            vm.CardItems = await _context.CardItems
                .AsNoTracking()
                .OrderBy(x => x.SortOrder)
                .ToListAsync();

            vm.Discount = await _context.Discounts
               .AsNoTracking()
               .FirstOrDefaultAsync();

            return View(vm);
        }

        public async Task<IActionResult> Careers()
        {
            CareersPageVM vm = new CareersPageVM();

            vm.Career = await _context.Careers
                .AsNoTracking()
                .FirstOrDefaultAsync();

            vm.CardItems = await _context.CardItems
                .AsNoTracking()
                .OrderBy(x => x.SortOrder)
                .ToListAsync();

            vm.Discount = await _context.Discounts
               .AsNoTracking()
               .FirstOrDefaultAsync();

            return View(vm);
        }

    }
}
