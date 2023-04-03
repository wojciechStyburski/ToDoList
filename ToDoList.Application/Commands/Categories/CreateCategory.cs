namespace ToDoList.Application.Commands.Categories;

public record CreateCategory(Guid Id, string Name, string Description, Guid UserId) : ICommand;
