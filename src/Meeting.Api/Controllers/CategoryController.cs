using Meeting.Core.Services.Categories;
using Meeting.Core.Services.Categories.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Meeting.Api.Controllers;

[ApiController]
[Route("api/category")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryAppService _categoryAppService;

    public CategoryController(ICategoryAppService categoryAppService)
    {
        _categoryAppService = categoryAppService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() { 
        return Ok(await _categoryAppService.GetAll());
    }

    [HttpGet("get-cat")]
    public async Task<IActionResult> GetById(string id)
    {
        return Ok(await _categoryAppService.GetById(id));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateCategoryDto input)
    {
        if (input.Name == null) return BadRequest();
        return Ok(await _categoryAppService.Update(input));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] CreateCategoryDto input, string id)
    {
        if (id == null) return BadRequest();
        var category = await _categoryAppService.GetById(id);
        category.Name = input.Name;
        category.Description = input.Description;

        return Ok(await _categoryAppService.Delete(category));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryDto input)
    {
        if (input.Name == null) return BadRequest();
        return Ok(await _categoryAppService.Create(input));
    }
}