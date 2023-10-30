using Loja.Dtos.ProductMapper;

namespace Loja.Service.Interface;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetAllProduct();
    Task<ProductDTO> GetProductById(long id);
    Task<ProductDTO> PostProduct(PostProductDTO entity);
    Task<ProductDTO> PutProduct(long id, ProductDTO entity);
    Task<ProductDTO> DeleteProduct(long id);
}
