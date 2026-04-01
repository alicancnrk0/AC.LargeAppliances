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

        public IActionResult Index()
        {
            return View();
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


        public IActionResult Vendors() 
        {
            return View();
        }


        public IActionResult Products()
        {
            return View();
        }


        public IActionResult ProductView()
        {
            return View();
        }

        public IActionResult Term()
        {
            return View();
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
