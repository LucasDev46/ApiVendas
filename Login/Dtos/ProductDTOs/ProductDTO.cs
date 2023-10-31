namespace Loja.Dtos.ProductMapper;

public class ProductDTO
{
    public long ProductId { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
    public int stock { get; init; }
    public long CategoryId { get; init; }
}
