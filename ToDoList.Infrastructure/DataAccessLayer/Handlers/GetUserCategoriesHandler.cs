namespace ToDoList.Infrastructure.DataAccessLayer.Handlers;

internal sealed class GetUserCategoriesHandler : IQueryHandler<GetUserCategories, IEnumerable<CategoryDto>>
{
    private readonly ToDoListDbContext _dbContext;

    public GetUserCategoriesHandler(ToDoListDbContext dbContext) 
        => _dbContext = dbContext;


    public async Task<IEnumerable<CategoryDto>> HandleAsync(GetUserCategories query)
        => await _dbContext.Categories.AsNoTracking().Select(x => x.AsDto()).ToListAsync();
}