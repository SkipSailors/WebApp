using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    using Microsoft.AspNetCore.Mvc.ViewComponents;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Models;

    [ViewComponent(Name = "CitesControllerHybrid")]
    public class CitiesController : Controller
    {
        private readonly CityData data;

        public CitiesController(CityData cdata)
        {
            data = cdata;
        }

        public IActionResult Index()
        {
            return View(data.Cities);
        }
        
        public IViewComponentResult Invoke()
        {
            return new ViewViewComponentResult()
            {
                ViewData = new ViewDataDictionary<CityViewModel>(
                    ViewData,
                    new CityViewModel
                    {
                        Cities = data.Cities.Count(),
                        Population = data.Cities.Sum(c => c.Population)
                    })
            };
        }
    }
}
