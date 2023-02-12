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
    public IAsyncEnumerable<Product> GetProducts()
    {
        return context.Products.AsAsyncEnumerable();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult?> GetProduct(long id)
    {
        Product? p = await context.Products.FindAsync(id);
        return p == null
            ? NotFound()
            : Ok(p);
    }

    [HttpPost]
    public async Task<IActionResult> SaveProduct([FromBody] ProductBindingTarget target)
    {
        Product p = target.ToProduct();
        await context.Products.AddAsync(p);
        await context.SaveChangesAsync();
        return Ok(p);
    }

    [HttpPut]
    public async Task UpdateProduct([FromBody] Product product)
    {
        context.Update(product);
        await context.SaveChangesAsync();
    }

    [HttpDelete("{id}")]
    public async Task DeleteProduct(long id)
    {
        context.Products.Remove(new Product { ProductId = id });
        await context.SaveChangesAsync();
    }
}