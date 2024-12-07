using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebUI.Controllers
{
    [AllowAnonymous]
    public class OurServiceController : Controller
    {
        public IActionResult Index()
        {
           
            return View();
        }
    }
}
