using Loja.Config.Enum;
using Loja.Dtos.CategoryMapper;
using Loja.Errors;
using Loja.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;


namespace Loja.Controllers;
[ApiController]
[Route("[Controller]")]
//[Authorize(AuthenticationSchemes = "Bearer", Roles = "Manager")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAsync()
    {
        var categorys = await _categoryService.GetAllCategory();
        if (categorys is null)
        {
            return BadRequest("hmm, deu ruim");
        }
        return Ok(categorys);
    }

    [HttpGet("id:int")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var category = await _categoryService.GetCategoryById(id);
        if (category is null)
        {
            return BadRequest("Category not found");
        }
        return Ok(category);
    }

    [HttpGet("product")]
    public async Task<ActionResult<IEnumerable<CategoryProductDTO>>> GetCategoryProductAsync()
    {
        var category = await _categoryService.GetCategoryProductAsync();
        if (category is null)
        {
            return BadRequest("sei nao, em");
        }
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(PostCategoryDTO categoryDto)
    {
        var category = await _categoryService.PostCategory(categoryDto);
        if (category is null)
        {
            return BadRequest("hmm, deu ruim");
        }

        return Ok(category);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<CategoryDTO>> PutAsync(long id, CategoryDTO categoryDto)
    {
        var category = await _categoryService.PutCategory(id, categoryDto);
        if (category is null)
        {
            return BadRequest("não encontrado");
        }
        return Ok(category);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var category = await _categoryService.DeleteCategory(id);

        if (category is null)
        {
            return UnprocessableEntity(new ResultError { Sucess = false, Message = $"Product ID {id} Not Found" });
        }
        return Ok(category);
    }

}
