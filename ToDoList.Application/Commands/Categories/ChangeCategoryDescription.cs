namespace ToDoList.Application.Commands.Categories;

public record ChangeCategoryDescription(string Name, string Description, Guid UserId) : ICommand;
