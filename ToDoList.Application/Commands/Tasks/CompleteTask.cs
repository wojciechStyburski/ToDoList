namespace ToDoList.Application.Commands.Tasks;

public record CompleteTask(Guid TaskId) : ICommand;
