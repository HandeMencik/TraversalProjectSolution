﻿using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.ViewComponents.UILayout
{
    public class _NavbarUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
