namespace ToDoList.Infrastructure.DataAccessLayer.Handlers;

internal sealed class GetCategoriesHandler : IQueryHandler<GetCategories, IEnumerable<CategoryDto>>
{
    private readonly ToDoListDbContext _dbContext;

    public GetCategoriesHandler(ToDoListDbContext dbContext) 
        => _dbContext = dbContext;

    public async Task<IEnumerable<CategoryDto>> HandleAsync(GetCategories query) 
        => await _dbContext.Categories.AsNoTracking().Select(x => x.AsDto()).ToListAsync();
}