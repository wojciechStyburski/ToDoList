namespace ToDoList.Application.Queries;

public class GetUserDetails : IQuery<UserDto>
{
    public Guid Id { get; set; }
}