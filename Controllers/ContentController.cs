namespace WebApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

[ApiController]
[Route("/api/[controller]")]
public class ContentController : ControllerBase
{
    private DataContext context;

    public ContentController(DataContext ctx)
    {
        context = ctx;
    }

    [HttpGet("string")]
    public string GetString() => "This is a string response";

    [HttpGet("object")]
    [Produces("application/josn")]
    public async Task<ProductBindingTarget> GetObject()
    {
        Product p = await context.Products.FirstAsync();
        return new ProductBindingTarget()
        {
            Name = p.Name,
            Price = p.Price,
            CategoryId = p.CategoryId,
            SupplierId = p.SupplierId
        };
    }
}