﻿using Microsoft.AspNetCore.Mvc;

namespace ERP_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
