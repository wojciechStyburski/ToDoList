namespace ToDoList.Core.Entities;

public class Tasks
{
    public TaskId Id { get; }
    public TaskName TaskName { get; }
    public bool IsCompleted { get; private set; }
    public CategoryId CategoryId { get; }
    public Category Category { get; }
    public UserId UserId { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; private set; }
    public Tasks(TaskId id, TaskName taskName, CategoryId categoryId, UserId userId)
    {
        Id = id;
        TaskName = taskName;
        IsCompleted = false;
        CategoryId = categoryId;
        UserId = userId;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void CompleteTask()
    {
        IsCompleted = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void RestoreTask()
    {
        IsCompleted = false;
        UpdatedAt = DateTime.UtcNow;
    }
}