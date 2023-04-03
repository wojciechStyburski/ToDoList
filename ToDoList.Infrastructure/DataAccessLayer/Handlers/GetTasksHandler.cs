namespace ToDoList.Infrastructure.DataAccessLayer.Handlers;

internal class GetTasksHandler : IQueryHandler<GetTasks, Result<TaskDto>>
{
    private readonly ISieveProcessor _sieveProcessor;
    private readonly ToDoListDbContext _dbContext;

    public GetTasksHandler(ISieveProcessor sieveProcessor, ToDoListDbContext dbContext)
    {
        _sieveProcessor = sieveProcessor;
        _dbContext = dbContext;
    }

    public async Task<Result<TaskDto>> HandleAsync(GetTasks query)
    {
        var sieveModel = new SieveModel()
        {
            PageSize = query.PageSize,
            Filters = string.Empty,
            Page = query.Page,
            Sorts = string.Empty
        };

        var userTasks = _dbContext
            .Tasks
            .Include(x => x.Category)
            .Where(x => x.UserId == new UserId(query.UserId))
            .AsQueryable();

        var userTasksDto = await _sieveProcessor
            .Apply(sieveModel, userTasks)
            .Select(x => x.AsDto())
            .ToListAsync();

       var totalCount = await _sieveProcessor
            .Apply(sieveModel, userTasks, applyPagination: false, applySorting:false)
            .CountAsync();

       var result = new Result<TaskDto>(userTasksDto, totalCount, sieveModel.PageSize.Value, sieveModel.Page.Value);

       return result;
    }
}