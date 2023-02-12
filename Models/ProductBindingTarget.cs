namespace WebApp.Models;

using System.ComponentModel.DataAnnotations;

public class ProductBindingTarget
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Range(1, 1000)]
    public decimal Price { get; set; }

    [Range(1, long.MaxValue)]
    public long CategoryId { get; set; }

    [Range(1, long.MaxValue)]
    public long SupplierId { get; set; }

    public Product ToProduct() => new()
        {
            Name = Name,
            Price = Price,
            CategoryId = CategoryId,
            SupplierId = SupplierId
        };
}