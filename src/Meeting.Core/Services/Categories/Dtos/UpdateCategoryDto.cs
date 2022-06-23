using Meeting.Core.Entities;

namespace Meeting.Core.Services.Categories.Dtos;

public class UpdateCategoryDto
{
    public string Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    public Category ToEntity()
    {
        return new Category
        {
            Name = Name,
            Description = Description
        };
    }
}