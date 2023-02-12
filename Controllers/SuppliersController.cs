namespace WebApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models;

    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController: ControllerBase
    {
        private DataContext context;

        public SuppliersController(DataContext ctx)
        {
            context = ctx;
        }

        [HttpGet("{id}")]
        public async Task<Supplier?> GetSupplier(long id)
        {
            return await context
                .Suppliers
                .Include(s => s.Products)
                .FirstAsync(s => s.SupplierId == id);
        }
    }
}
