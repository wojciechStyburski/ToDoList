namespace ToDoList.Infrastructure.DataAccessLayer.Repositories;

internal sealed class TaskRepository : ITaskRepository
{
    private readonly ToDoListDbContext _dbContext;
    public TaskRepository(ToDoListDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task<Tasks> GetByIdAsync(TaskId id) 
        => _dbContext.Tasks.SingleOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<Tasks>> GetAllAsync() 
        => await _dbContext.Tasks.ToListAsync();

    public async Task<IEnumerable<Tasks>> GetByUserAsync(UserId userId) 
        => await _dbContext.Tasks.Where(x => x.UserId == userId).ToListAsync();

    public async Task<IEnumerable<Tasks>> GetByCategoryAsync(CategoryId categoryId) 
        => await _dbContext.Tasks.Where(x => x.CategoryId == categoryId).ToListAsync();

    public async Task AddAsync(Tasks task) 
        => await _dbContext.AddAsync(task);

    public Task UpdateAsync(Tasks task)
    {
        _dbContext.Update(task);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Tasks task)
    {
        _dbContext.Remove(task);
        await _dbContext.SaveChangesAsync();
    }
}