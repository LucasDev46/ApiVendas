using AutoMapper;
using Loja.Dtos.ProductMapper;
using Loja.Models;
using Loja.Repository.Interface;
using Loja.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Loja.Service;
public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetAllProduct()
    {
        var products = await _unitOfWork._productRepository.Get().ToListAsync();
        if (products is null)
        {
            return Enumerable.Empty<ProductDTO>();
        }
        var produtosDto = _mapper.Map<List<ProductDTO>>(products);
        return produtosDto;
    }

    public async Task<ProductDTO> GetProductById(long id)
    {
        var product = await _unitOfWork._productRepository.GetByQuery(p => p.ProductId == id);
        if (product is null)
        {
            return null;
        }
        var productDto = _mapper.Map<ProductDTO>(product);
        return productDto;
    }

    public async Task<ProductDTO> PostProduct(PostProductDTO entity)
    {
        var product = _mapper.Map<Product>(entity);
        if (product is null)
        {
            return null;
        }
        _unitOfWork._productRepository.Add(product);
        await _unitOfWork.Commit();
        var productDto = _mapper.Map<ProductDTO>(product);
        return productDto;
    }

    public async Task<ProductDTO> PutProduct(long id, ProductDTO entity)
    {
        
        if (id != entity.ProductId)
        {
            return null;
        }
        var product = _mapper.Map<Product>(entity);

        _unitOfWork._productRepository.Update(product);
        await _unitOfWork.Commit();
        var productDto = _mapper.Map<ProductDTO>(product);
        return productDto;
    }
    public async Task<ProductDTO> DeleteProduct(long id)
    {
        var product = await _unitOfWork._productRepository.GetByQuery(c => c.ProductId == id);
        if (product is null)
        {
            return null;
        }
        _unitOfWork._productRepository.Delete(product);
        await _unitOfWork.Commit();
        var productDTO = _mapper.Map<ProductDTO>(product);
        return productDTO;
    }
}
