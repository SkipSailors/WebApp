﻿namespace WebApp.Components
{
    using Microsoft.AspNetCore.Mvc;

    public class PageSize: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync("http://apress.com");
            long l = response.Content.Headers.ContentLength ?? 0;
            return View(l);
        }
    }
}
