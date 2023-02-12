namespace WebApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using Models;

[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly DataContext context;

    /// <inheritdoc />
    public ProductsController(DataContext ctx)
    {
        context = ctx;
    }

    [HttpGet]
    public IEnumerable<Product> GetProducts()
    {
        return context.Products;
    }

    [HttpGet("{id}")]
    public Product? GetProduct(long id, [FromServices] ILogger<ProductsController> logger)
    {
        logger.LogDebug("GetProduct Action Invoked");
        return context.Products.Find(id);
    }

    [HttpPost]
    public void SaveProduct([FromBody] Product product)
    {
        context.Products.Add(product);
        context.SaveChanges();
    }

    [HttpPut]
    public void UpdateProduct([FromBody] Product product)
    {
        context.Products.Update(product);
        context.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void DeleteProduct(long id)
    {
        context.Products.Remove(new Product { ProductId = id });
        context.SaveChanges();
    }
}