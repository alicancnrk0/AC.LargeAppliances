using AC.LargeAppliances.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AC.LargeAppliances.Areas.Management.Controllers
{
    [Area("Management")]
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly EcomDbContext _context;

        public AuthController(EcomDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserName == username && x.Password == password);

            if (user != null)
            {
                var claim = new List<Claim>()
                {
                    new Claim("Email", user.Email),
                    new Claim("Username", username),
                    new Claim("Name", user.Name),
                };

                var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                var prop = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                    IsPersistent = true,
                    IssuedUtc = DateTimeOffset.UtcNow,
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity), prop);

                return RedirectToAction("Index", "Dashboard");
            }

            ViewBag.Error = "Kullanıcı adı veya şifre hatalı.";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}