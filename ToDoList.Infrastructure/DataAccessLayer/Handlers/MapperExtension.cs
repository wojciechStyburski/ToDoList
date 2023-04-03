namespace ToDoList.Infrastructure.DataAccessLayer.Handlers;

internal static class MapperExtension
{
    public static CategoryDto AsDto(this Category entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description
    };

    public static TaskDto AsDto(this Tasks entity) => new()
    {
        TaskId = entity.Id,
        TaskName = entity.TaskName,
        IsCompleted = entity.IsCompleted,
        Category = entity.Category.Name.Value,
        CreatedAt = entity.CreatedAt
    };

    public static UserDto AsDto(this User user) => new()
    {
        Id = user.Id,
        Email = user.Email,
        CreatedAt = user.CreatedAt,
        Role = user.Role,
        UserName = user.UserName
    };
}