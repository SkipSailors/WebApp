namespace WebApp.Models;

using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    /// <inheritdoc />
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
}