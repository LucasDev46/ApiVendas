using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Loja.Models;

public class Order
{
    [Key]
    public long OrderId { get; set; }

    public DateTime Date { get; set; } = DateTime.UtcNow;
    public long CustomerId { get; set; }
    [Required]
    [JsonIgnore]
    public Customer Customer { get; set; }

    public ICollection<ProductOrder> ProductOrder { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal TotalValue { get; set; }

    public Order()
    {
        ProductOrder = new List<ProductOrder>();
    }

}
