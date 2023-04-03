namespace ToDoList.Core.Repositories;

public interface ICategoryRepository
{
    Task<Category> GetByIdAsync(CategoryId id);
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category> GetByNameAsync(CategoryName name);
    Task AddAsync (Category category);
    Task UpdateAsync (Category category);
    Task DeleteAsync(Category category);
}