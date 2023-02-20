namespace WebApp.Components;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Models;

public class CitySummary : ViewComponent
{
    private readonly CityData data;

    public CitySummary(CityData cdata)
    {
        data = cdata;
    }

    public string Invoke()
    {
        return RouteData.Values["controller"] != null
            ? "Controller Request"
            : "Razor Page Request";
    }
}