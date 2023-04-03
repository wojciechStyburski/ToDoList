namespace ToDoList.Infrastructure.DataAccessLayer;

internal sealed class DatabaseOptions
{
    [Required]
    public string ConnectionString { get; set; }
}