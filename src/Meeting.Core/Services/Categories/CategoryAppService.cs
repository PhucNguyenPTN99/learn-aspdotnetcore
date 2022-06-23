using Meeting.Core.Entities;
using Meeting.Core.Interfaces;
using Meeting.Core.Services.Categories.Dtos;

namespace Meeting.Core.Services.Categories;

public class CategoryAppService : ICategoryAppService
{
    private readonly IRepository<Category> _categoryRepository;

    public CategoryAppService(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryDto> Create(CreateCategoryDto input)
    {
        var category = Map(input);
        var entity = await _categoryRepository.AddAsync(category, CancellationToken.None);
        return Map(entity);
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _categoryRepository.ListAllAsync(CancellationToken.None);
    }

    public async Task<Category> GetById(String id)
    {
        return await _categoryRepository.GetByIdAsync(id, CancellationToken.None);
    }

    public async Task<CategoryDto> Update(UpdateCategoryDto input)
    {
        var cate = await _categoryRepository.GetByIdAsync(input.Id, CancellationToken.None);
        Map(cate, input);
        var entity = await _categoryRepository.UpdateAsync(cate, CancellationToken.None);
        return Map(entity);
    }

    public async Task<bool> Delete(Category cate)
    {
        return await _categoryRepository.DeleteAsync(cate, CancellationToken.None);
    }

    private Category Map(CreateCategoryDto dto)
    {
        return new Category
        {
            Name = dto.Name,
            Description = dto.Description
        };
    }

    private void Map(Category cate, UpdateCategoryDto dto)
    {

        cate.Name = dto.Name;
        cate.Description = dto.Description;
    }

    private CategoryDto Map(Category category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };
    }
}