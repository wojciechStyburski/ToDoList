namespace ToDoList.Application.DataTransferObject;

public class TaskDto
{
    public Guid TaskId { get; set; }
    public string TaskName { get; set; }
    public bool IsCompleted { get; set; }
    public string Category { get; set; }
    public DateTime CreatedAt { get; set; }

}