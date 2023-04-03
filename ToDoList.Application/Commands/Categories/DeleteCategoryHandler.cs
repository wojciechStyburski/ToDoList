namespace ToDoList.Application.Commands.Categories;

public sealed class DeleteCategoryHandler : ICommandHandler<DeleteCategory>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task HandleAsync(DeleteCategory command)
    {
        var category = await _categoryRepository.GetByIdAsync(command.CategoryId);
        if (category is null)
            throw new CategoryNotFoundException(command.CategoryId.ToString());

        await _categoryRepository.DeleteAsync(category);
    }
}