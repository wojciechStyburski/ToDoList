namespace ToDoList.Application.Queries;

public class GetTasks : IQuery<Result<TaskDto>>
{
    public Guid UserId { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string Sort { get; set; }
    public string Filter { get; set; }
}