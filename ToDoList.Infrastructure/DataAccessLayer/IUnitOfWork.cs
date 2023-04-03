namespace ToDoList.Infrastructure.DataAccessLayer;

public interface IUnitOfWork
{
    Task ExecuteAsync(Func<Task> action);
}