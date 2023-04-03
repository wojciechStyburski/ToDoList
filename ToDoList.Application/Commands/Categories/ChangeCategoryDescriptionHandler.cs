using ToDoList.Core.ValueObjects;

namespace ToDoList.Application.Commands.Categories;

public class ChangeCategoryDescriptionHandler : ICommandHandler<ChangeCategoryDescription>
{
    private readonly ICategoryRepository _categoryRepository;

    public ChangeCategoryDescriptionHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task HandleAsync(ChangeCategoryDescription command)
    {
        var category = await _categoryRepository.GetByNameAsync(command.Name);
        if (category is null)
            throw new CategoryNotFoundException(command.Name);

        if (category.UserId.Value != command.UserId)
            throw new CategoryNotFoundException(command.Name);

        category.ChangeCategoryDescription(command.Description);
        await _categoryRepository.UpdateAsync(category);
    }
}