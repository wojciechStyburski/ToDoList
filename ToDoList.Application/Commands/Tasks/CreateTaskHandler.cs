namespace ToDoList.Application.Commands.Tasks;

public class CreateTaskHandler : ICommandHandler<CreateTask>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUserRepository _userRepository;
    private readonly ICategoryRepository _categoryRepository;

    public CreateTaskHandler(ITaskRepository taskRepository, IUserRepository userRepository, ICategoryRepository categoryRepository)
    {
        _taskRepository = taskRepository;
        _userRepository = userRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task HandleAsync(CreateTask command)
    {
        var taskId = new TaskId(command.TaskId);
        var taskName = new TaskName(command.TaskName);
        var categoryId = new CategoryId(command.CategoryId);
        var userId = new UserId(command.UserId);

        if (await _categoryRepository.GetByIdAsync(categoryId) is null)
            throw new CategoryNotFoundException(categoryId.ToString());

        if (await _userRepository.GetByIdAsync(userId) is null)
            throw new UserNotFoundException(userId);

        var newTask = new Core.Entities.Tasks(taskId, taskName, categoryId, userId);
        await _taskRepository.AddAsync(newTask);
    }
}