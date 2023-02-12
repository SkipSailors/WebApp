namespace WebApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using Models;

[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private DataContext context;

    /// <inheritdoc />
    public ProductController(DataContext ctx)
    {
        context = ctx;
    }

    [HttpGet]
    public IEnumerable<Product> GetProducts()
    {
        return context.Products;
    }

    [HttpGet("{id}")]
    public Product? GetProduct([FromServices] ILogger<ProductController> logger)
    {
        logger.LogDebug("GetProduct Action Invoked");
        return context.Products.FirstOrDefault();
    }
}