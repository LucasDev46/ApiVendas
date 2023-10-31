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

public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet, AllowAnonymous]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategory()
    {
        var categorys = await _categoryService.GetAllCategory();
        if (categorys is null)
        {
            return BadRequest(new ResultError {Sucess = false, Message = "Error" });
        }
        return Ok(categorys);
    }

    [HttpGet("id:int"), AllowAnonymous]
    public async Task<IActionResult> GetCategoryById(long id)
    {
        var category = await _categoryService.GetCategoryById(id);
        if (category is null)
        {
            return BadRequest(new ResultError { Sucess = false, Message = "Category not Found" });
        }
        return Ok(category);
    }

    [HttpGet("product"), AllowAnonymous]
    public async Task<ActionResult<IEnumerable<CategoryProductDTO>>> GetCategoryProductAsync()
    {
        var category = await _categoryService.GetCategoryProductAsync();
        if (category is null)
        {
            return BadRequest(new ResultError { Sucess = false, Message = "Error" });
        }
        return Ok(category);
    }

    [HttpPost]
    //[Authorize(Roles = "Manager")]
    public async Task<IActionResult> CreateCategory(PostCategoryDTO categoryDto)
    {
        var category = await _categoryService.CreateCategory(categoryDto);
        if (category is null)
        {
            return BadRequest("hmm, deu ruim");
        }

        return Ok(category);
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Manager")]
    public async Task<ActionResult<CategoryDTO>> UpdateCategory(long id, CategoryDTO categoryDto)
    {
        var category = await _categoryService.UpdateCategory(id, categoryDto);
        if (category is null)
        {
            return BadRequest("não encontrado");
        }
        return Ok(category);
    }

    [HttpDelete]
    [Authorize(Roles = "Manager")]
    public async Task<IActionResult> DeleteCategory(long id)
    {
        var category = await _categoryService.DeleteCategory(id);

        if (category is null)
        {
            return UnprocessableEntity(new ResultError { Sucess = false, Message = $"Product ID {id} Not Found" });
        }
        return Ok(category);
    }

}
