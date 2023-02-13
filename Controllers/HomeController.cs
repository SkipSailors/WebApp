using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
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
            return View(await context.Products.FindAsync(id));
        }

        public IActionResult List()
        {
            return View(context.Products);
        }
    }
}
