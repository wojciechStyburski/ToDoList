namespace ToDoList.Core.Repositories;

public interface ITaskRepository
{
    Task<Tasks> GetByIdAsync(TaskId id);
    Task<IEnumerable<Tasks>> GetAllAsync();
    Task<IEnumerable<Tasks>> GetByUserAsync(UserId userId);
    Task<IEnumerable<Tasks>> GetByCategoryAsync(CategoryId categoryId);
    Task AddAsync(Tasks task);
    Task UpdateAsync(Tasks task);
    Task DeleteAsync(Tasks task);

}