using Loja.Dtos.CategoryMapper;

namespace Loja.Service.Interface;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetAllCategory();
    Task<CategoryDTO> GetCategoryById(long id);
    Task<CategoryDTO> CreateCategory(PostCategoryDTO entity);
    Task<CategoryDTO> UpdateCategory(long id, CategoryDTO entity);
    Task<CategoryDTO> DeleteCategory(long id);
    Task<IEnumerable<CategoryProductDTO>> GetCategoryProductAsync();
}
