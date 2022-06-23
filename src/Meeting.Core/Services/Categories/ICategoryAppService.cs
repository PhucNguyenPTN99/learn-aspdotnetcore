using Meeting.Core.Services.Categories.Dtos;
using Meeting.Core.Entities;
using System.Collections;

namespace Meeting.Core.Services.Categories;

public interface ICategoryAppService
{
    Task<CategoryDto> Create(CreateCategoryDto input);
    Task<IEnumerable<Category>> GetAll();
    Task<Category> GetById(String id);
    Task<bool> Delete(Category cate);
    Task<CategoryDto> Update(UpdateCategoryDto cate);
}