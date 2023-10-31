using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Loja.Models;

public class Order
{
    [Key]
    public long OrderId { get; set; }

    public DateTime Date { get; set; } = DateTime.UtcNow;
    [Required]
    [JsonIgnore]
    public Customer Client { get; set; }
    public long ClientId { get; set; }
    public long ProductId { get; set; }
    public ICollection<Product> Products { get; set; }
    public int Quantity { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal TotalValue { get; set; }

    public Order()
    {
        Products = new List<Product>();
    }

}
