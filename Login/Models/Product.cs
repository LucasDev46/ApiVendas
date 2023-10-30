using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Loja.Models;

public class Product
{
    public long ProductId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [StringLength(100)]
    public string Description { get; set; }
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }
    public int stock { get; set; }
    public DateTime HourRegister { get; set; } = DateTime.Now;
    public long CategoryId { get; set; }
    [JsonIgnore]
    public Category? Category { get; set; }
    public ICollection<Order> Order { get; set; }

    public Product()
    {
        Order = new List<Order>();
    }
}
