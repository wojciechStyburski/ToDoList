namespace ToDoList.Application.Commands.Tasks;

public class RestoreTaskHandler : ICommandHandler<RestoreTask>
{
    private readonly ITaskRepository _taskRepository;

    public RestoreTaskHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task HandleAsync(RestoreTask command)
    {
        var task = await _taskRepository.GetByIdAsync(command.TaskId);
        if (task is null)
            throw new TaskNotFoundException(command.TaskId);

        task.RestoreTask();
        await _taskRepository.UpdateAsync(task);
    }
}