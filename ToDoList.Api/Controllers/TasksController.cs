namespace ToDoList.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class TasksController : ControllerBase
{
    private readonly ICommandHandler<CreateTask> _createTaskHandler;
    private readonly ICommandHandler<CompleteTask> _completeTaskHandler;
    private readonly ICommandHandler<RestoreTask> _restoreTaskHandler;

    private readonly IQueryHandler<GetTasks, Result<TaskDto>> _tasksQueryHandler;

    public TasksController(
        ICommandHandler<CreateTask> createTaskHandler, 
        ICommandHandler<CompleteTask> completeTaskHandler, 
        ICommandHandler<RestoreTask> restoreTaskHandler, 
        IQueryHandler<GetTasks, Result<TaskDto>> tasksQueryHandler)
    {
        _createTaskHandler = createTaskHandler;
        _completeTaskHandler = completeTaskHandler;
        _restoreTaskHandler = restoreTaskHandler;
        _tasksQueryHandler = tasksQueryHandler;
    }

    [HttpGet]
    public async Task<ActionResult<Result<TaskDto>>> GetAllUserTasks(GetTasks query)
    {
        query.UserId = Guid.Parse(User.Identity.Name);
        return Ok(await _tasksQueryHandler.HandleAsync(query));
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateTask command)
    {
        await _createTaskHandler.HandleAsync(command with
        {
            TaskId = Guid.NewGuid(),
            UserId = Guid.Parse(User.Identity.Name)
        });

        return CreatedAtAction(nameof(Create), new { id = command.TaskId }, null);
    }

    [HttpPut("complete-task/{taskId:guid}")]
    public async Task<ActionResult> CompleteTask(Guid taskId)
    {
        await _completeTaskHandler.HandleAsync(new CompleteTask(TaskId: taskId));
        return NoContent();
    }

    [HttpPut("restore-task/{taskId:guid}")]
    public async Task<ActionResult> RestoreTask(Guid taskId)
    {
        await _restoreTaskHandler.HandleAsync(new RestoreTask(TaskId: taskId));
        return NoContent();
    }
}
