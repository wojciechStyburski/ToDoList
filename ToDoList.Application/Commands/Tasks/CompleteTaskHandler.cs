namespace ToDoList.Application.Commands.Tasks;

public class CompleteTaskHandler : ICommandHandler<CompleteTask>
{
    private readonly ITaskRepository _taskRepository;

    public CompleteTaskHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task HandleAsync(CompleteTask command)
    {
        var task = await _taskRepository.GetByIdAsync(command.TaskId);
        if (task is null)
            throw new TaskNotFoundException(command.TaskId);

        task.CompleteTask();
        await _taskRepository.UpdateAsync(task);
    }
}