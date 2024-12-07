using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebUI.ViewComponents.AboutViewComponents
{
    public class BecomeADriverComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}


