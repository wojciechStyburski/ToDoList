var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddControllers();

var app = builder.Build();

app
    .UseStaticFiles();

app
    .UseInfrastructure()
    .MapControllers();

app.Run();
