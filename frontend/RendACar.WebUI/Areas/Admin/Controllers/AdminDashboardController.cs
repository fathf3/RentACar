using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebUI.Areas.Admin.Controllers
{
    public class AdminDashboardController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
