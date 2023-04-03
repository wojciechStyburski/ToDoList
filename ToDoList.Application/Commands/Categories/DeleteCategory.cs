namespace ToDoList.Application.Commands.Categories;

public sealed record DeleteCategory(Guid CategoryId) : ICommand;
