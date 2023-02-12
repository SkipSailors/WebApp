namespace WebApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [ApiController]
    [Route("ap/[controller]")]
    public class SupplierController: ControllerBase
    {
        private DataContext context;

        public SupplierController(DataContext ctx)
        {
            context = ctx;
        }

        [HttpGet("{id}")]
        public async Task<Supplier?> GetSupplier(long id)
        {
            return await context.Suppliers.FindAsync(id);
        }
    }
}
