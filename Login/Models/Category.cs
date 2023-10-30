using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Loja.Models;

public class Category
{
    public long CategoryId { get; set; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }

    public ICollection<Product> Products { get; set; }


    public Category()
    {
        Products = new Collection<Product>();
    }

}
