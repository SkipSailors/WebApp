﻿using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class HomeController : Controller
    {
        private DataContext context;

        public HomeController(DataContext ctx)
        {
            context = ctx;
        }

        public async Task<IActionResult> Index(long id=1)
        {
            ViewBag.AveragePrice = await context.Products.AverageAsync(p => p.Price);
            return View(await context.Products.FindAsync(id));
        }

        public IActionResult List()
        {
            return View(context.Products);
        }

        public IActionResult Html()
        {
            return View((object)"This is a <h3><i>string</i></h3>");
        }
    }
}
