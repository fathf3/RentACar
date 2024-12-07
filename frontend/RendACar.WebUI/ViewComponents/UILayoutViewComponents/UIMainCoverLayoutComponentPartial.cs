using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebUI.ViewComponents.UILayoutViewComponents
{
    public class UIMainCoverLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

