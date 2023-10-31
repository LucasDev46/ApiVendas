namespace Loja.Dtos.ProductMapper;

public class PostProductDTO
{
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
    public int stock { get; init; }
    public long CategoryId { get; init; }
}
