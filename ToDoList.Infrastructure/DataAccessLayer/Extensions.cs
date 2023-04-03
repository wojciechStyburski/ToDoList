namespace ToDoList.Infrastructure.DataAccessLayer;

internal static class Extensions
{
    private const string DatabaseSectionName = "Database";

    public static IServiceCollection AddDatabaseConnection(this IServiceCollection services,
        IConfiguration configuration)
    {
        var section = configuration.GetSection(DatabaseSectionName);
        services.Configure<DatabaseOptions>(section);
        var dbOptions = configuration.GetOptions<DatabaseOptions>(DatabaseSectionName);

        services.AddDbContext<ToDoListDbContext>(options =>
        {
            options.UseSqlServer(dbOptions.ConnectionString);
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, DatabaseUnitOfWork>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();

        services.TryDecorate(typeof(ICommandHandler<>), typeof(UnitOfWorkCommandHandlerDecorator<>));
        services.AddHostedService<DatabaseInitializer>();
        
        return services;
    }


    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var options = new T();
        var section = configuration.GetSection(sectionName);
        section.Bind(options);

        return options;
    }
}