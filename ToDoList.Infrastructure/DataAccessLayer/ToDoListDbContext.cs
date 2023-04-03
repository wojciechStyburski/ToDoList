namespace ToDoList.Infrastructure.DataAccessLayer;

internal sealed class ToDoListDbContext : DbContext
{
    public DbSet<User> Users { get; set; }  
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tasks> Tasks { get; set; }
    public ToDoListDbContext(DbContextOptions<ToDoListDbContext> dbContextOptions) : base(dbContextOptions) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}