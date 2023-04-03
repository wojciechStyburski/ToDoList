namespace ToDoList.Application.Queries;

public class GetUserCategories : IQuery<IEnumerable<CategoryDto>>
{
    public Guid UserId { get; set; }
}
