﻿using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebUI.ViewComponents.UILayoutViewComponents
{
    public class UIHeadLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
