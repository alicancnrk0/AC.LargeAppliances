using Microsoft.AspNetCore.Mvc;

namespace AC.LargeAppliances.Areas.Management.Controllers
{
    [Area("Management")]
    public class CardsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
