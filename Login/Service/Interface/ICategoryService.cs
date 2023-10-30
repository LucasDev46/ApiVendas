using Loja.Dtos.CategoryMapper;

namespace Loja.Service.Interface;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetAllCategory();
    Task<CategoryDTO> GetCategoryById(long id);
    Task<CategoryDTO> PostCategory(PostCategoryDTO entity);
    Task<CategoryDTO> PutCategory(long id, CategoryDTO entity);
    Task<CategoryDTO> DeleteCategory(long id);
    Task<IEnumerable<CategoryProductDTO>> GetCategoryProductAsync();
}
