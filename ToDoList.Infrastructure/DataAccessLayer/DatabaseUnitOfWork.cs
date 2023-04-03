namespace ToDoList.Infrastructure.DataAccessLayer;

internal sealed class DatabaseUnitOfWork : IUnitOfWork
{
    private readonly ToDoListDbContext _dbContext;

    public DatabaseUnitOfWork(ToDoListDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task ExecuteAsync(Func<Task> action)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            await action();
            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}