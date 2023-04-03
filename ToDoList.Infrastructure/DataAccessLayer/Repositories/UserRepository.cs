namespace ToDoList.Infrastructure.DataAccessLayer.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly DbSet<User> _users;

    public UserRepository(ToDoListDbContext dbContext)
    {
        _users = dbContext.Users;
    }

    public Task<User> GetByIdAsync(UserId id) 
        => _users.SingleOrDefaultAsync(x => x.Id == id);
    public Task<User> GetByEmailAsync(Email email) 
        => _users.SingleOrDefaultAsync(x => x.Email == email);
    public Task<User> GetByUserNameAsync(UserName userName) 
        => _users.SingleOrDefaultAsync(x => x.UserName == userName);
    public async Task AddAsync(User user) 
        => await _users.AddAsync(user);
}