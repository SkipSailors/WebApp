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

    public string Invoke()
    {
        return $"{data.Cities.Count()} cities, " +
               $"{data.Cities.Sum(c => c.Population)}";
    }
}