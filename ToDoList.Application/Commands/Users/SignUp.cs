using ToDoList.Application.Abstractions.Commands;

namespace ToDoList.Application.Commands.Users;

public sealed record SignUp(Guid UserId, string Email, string UserName, string Password, string Role) : ICommand;
