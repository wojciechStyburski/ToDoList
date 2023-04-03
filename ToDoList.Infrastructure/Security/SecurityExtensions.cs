namespace ToDoList.Infrastructure.Security;

public static class SecurityExtensions
{
    public static IServiceCollection AddSecurity(this IServiceCollection services)
    {
        services
            .AddScoped<IPasswordHasher<User>, PasswordHasher<User>>()
            .AddScoped<IPasswordManager, PasswordManager>();

        return services;
    }
}