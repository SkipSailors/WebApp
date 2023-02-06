namespace WebApp.Models;

public class Category
{
    public long CategoriesId { get; set; }
    public string Name { get; set; } = string.Empty;
    public IEnumerable<Product>? Prooducts { get; set; }
}