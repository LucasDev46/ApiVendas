using Loja.Dtos.ProductMapper;

namespace Loja.Dtos.CategoryMapper;

public class CategoryProductDTO
{
    public long CategoryId { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }

    public ICollection<ProductDTO>? Products { get; init; }
}
