namespace ToDoList.Application.Commands.Tasks;

public record CreateTask(Guid TaskId, string TaskName, Guid CategoryId, Guid UserId) : ICommand;
