﻿using Microsoft.AspNetCore.Mvc;

namespace TraversalReservationProject.Areas.Member.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
