namespace ToDoList.Infrastructure.DataAccessLayer.Handlers;

internal class GetUserDetailsHandler : IQueryHandler<GetUserDetails, UserDto>
{
    private readonly ToDoListDbContext _dbContext;

    public GetUserDetailsHandler(ToDoListDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserDto> HandleAsync(GetUserDetails query)
    {
        var user = await _dbContext
            .Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == new UserId(query.Id));
        
        return user.AsDto();
    }
}