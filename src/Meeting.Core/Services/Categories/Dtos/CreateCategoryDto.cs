using Meeting.Core.Entities;

namespace Meeting.Core.Services.Categories.Dtos;

public class CreateCategoryDto
{
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