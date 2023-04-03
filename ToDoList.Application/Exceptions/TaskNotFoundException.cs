namespace ToDoList.Application.Exceptions;

public class TaskNotFoundException : CustomException
{
    public Guid TaskId { get; }

    public TaskNotFoundException(Guid taskId) 
        : base($"Task with id {taskId} not found")
        => TaskId = taskId;
}