﻿namespace WebApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using Models;

[ApiController]
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult?> GetProduct(long id)
    {
        Product? p = await context.Products.FindAsync(id);
        return p == null
            ? NotFound()
            : Ok(p);
    }

    [HttpPost]
    public async Task<IActionResult> SaveProduct(ProductBindingTarget target)
    {
        Product p = target.ToProduct();
        await context.Products.AddAsync(p);
        await context.SaveChangesAsync();
        return Ok(p);
    }

    [HttpPut]
    public async Task UpdateProduct(Product product)
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

    [HttpGet("redirect")]
    public IActionResult Redirect()
    {
        return RedirectToAction(nameof(GetProduct), new {id = 1});
    }
}