namespace WebApp.Components;

using Microsoft.AspNetCore.Mvc;
using Models;

public class CitySummary : ViewComponent
{
    private readonly CityData data;

    public CitySummary(CityData cdata)
    {
        data = cdata;
    }

    public IViewComponentResult Invoke(string themeName = "success")
    {
        ViewBag.Theme = themeName;
        return View(new CityViewModel
        {
            Cities = data.Cities.Count(),
            Population = data.Cities.Sum(c => c.Population)
        });
    }
}