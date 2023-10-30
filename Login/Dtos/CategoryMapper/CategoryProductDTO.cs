using Loja.Dtos.ProductMapper;

namespace Loja.Dtos.CategoryMapper;

public class CategoryProductDTO
{
    public long CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<ProductDTO>? Products { get; set; }
}
