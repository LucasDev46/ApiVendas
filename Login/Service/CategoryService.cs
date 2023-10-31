using AutoMapper;
using Loja.Dtos.CategoryMapper;
using Loja.Models;
using Loja.Repository.Interface;
using Loja.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Loja.Service;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDTO>> GetAllCategory()
    {
        var CategoryDTOs = await _unitOfWork._categoryRepository.SelectAll().ToListAsync();
        if (CategoryDTOs is null)
        {
            return Enumerable.Empty<CategoryDTO>();
        }
        var CategoryDTO = _mapper.Map<List<CategoryDTO>>(CategoryDTOs);
        return CategoryDTO;
    }

    public async Task<CategoryDTO> GetCategoryById(long id)
    {
        var category = await _unitOfWork._categoryRepository.SelectByQuery(c => c.CategoryId == id);

        if (category is null)
        {
            return null;
        }
        var categoryDto = _mapper.Map<CategoryDTO>(category);
        return categoryDto;
    }

    public async Task<IEnumerable<CategoryProductDTO>> GetCategoryProductAsync()
    {
        var category = await _unitOfWork._categoryRepository.SelectAllCategoryProduct();
        if (category is null)
        {
            return Enumerable.Empty<CategoryProductDTO>();
        }
        var CategoryDTO = _mapper.Map<List<CategoryProductDTO>>(category);
        return CategoryDTO;
    }

    public async Task<CategoryDTO> CreateCategory(PostCategoryDTO categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        if (category is null)
        {
            return null;
        }
        _unitOfWork._categoryRepository.Insert(category);
        await _unitOfWork.Commit();
        var teste = _mapper.Map<CategoryDTO>(category);
        return teste;
    }

    public async Task<CategoryDTO> UpdateCategory(long id, CategoryDTO categoryDto)
    {
        if (id != categoryDto.CategoryId)
        {
            return null;
        }
        var category = _mapper.Map<Category>(categoryDto);
         
        _unitOfWork._categoryRepository.Update(category);
        await _unitOfWork.Commit();
        return categoryDto;
    }

    public async Task<CategoryDTO> DeleteCategory(long id)
    {
        var category = await _unitOfWork._categoryRepository.SelectByQuery(p => p.CategoryId == id);
        if (category is null)
        {
            return null;
        }
        var categoryDto = _mapper.Map<CategoryDTO>(category);

        _unitOfWork._categoryRepository.Delete(category);
        await _unitOfWork.Commit();
        return categoryDto;
    }
}
