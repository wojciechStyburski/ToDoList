namespace ToDoList.Application.Commands.Categories;

public class CreateCategoryHandler : ICommandHandler<CreateCategory>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUserRepository _userRepository;

    public CreateCategoryHandler(ICategoryRepository categoryRepository, IUserRepository userRepository)
    {
        _categoryRepository = categoryRepository;
        _userRepository = userRepository;
    }
    public async Task HandleAsync(CreateCategory command)
    {
        var categoryId = new CategoryId(command.Id);
        var categoryName = new CategoryName(command.Name);
        var categoryDescription = new CategoryDescription(command.Description);
        var userId = new UserId(command.UserId);

        if (await _categoryRepository.GetByNameAsync(categoryName) is not null)
            throw new CategoryAlreadyInUseException(categoryName);

        if (await _userRepository.GetByIdAsync(userId) is null)
            throw new UserNotFoundException(userId);

        var newCategory = new Category(categoryId, categoryName, categoryDescription, userId);
        await _categoryRepository.AddAsync(newCategory);
    }
}