namespace ToDoList.Application.Commands.Tasks;

public record RestoreTask(Guid TaskId) : ICommand;
