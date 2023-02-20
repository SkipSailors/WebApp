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

    public IViewComponentResult Invoke()
    {
        return new HtmlContentViewComponentResult(new HtmlString("This is a <h3><i>string</i></h3>"));
    }
}