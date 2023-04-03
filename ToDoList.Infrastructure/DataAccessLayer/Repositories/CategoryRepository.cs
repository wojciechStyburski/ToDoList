namespace ToDoList.Infrastructure.DataAccessLayer.Repositories;

internal class CategoryRepository : ICategoryRepository
{
    private readonly ToDoListDbContext _dbContext;

    public CategoryRepository(ToDoListDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Category> GetByIdAsync(CategoryId id) 
        => _dbContext.Categories.SingleOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<Category>> GetAllAsync() 
        => await _dbContext.Categories.ToListAsync();

    public Task<Category> GetByNameAsync(CategoryName name) 
        => _dbContext.Categories.SingleOrDefaultAsync(x => x.Name == name);

    public async Task AddAsync(Category category) 
        => await _dbContext.AddAsync(category);

    public Task UpdateAsync(Category category)
    {
        _dbContext.Update(category);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Category category)
    {
        _dbContext.Remove(category);
        await _dbContext.SaveChangesAsync();
    }
}