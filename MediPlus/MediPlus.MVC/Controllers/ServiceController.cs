﻿using Microsoft.AspNetCore.Mvc;

namespace MediPlus.MVC.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
