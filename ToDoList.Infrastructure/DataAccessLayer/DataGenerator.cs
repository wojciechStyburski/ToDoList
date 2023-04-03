using System.Threading.Tasks;

namespace ToDoList.Infrastructure.DataAccessLayer;

internal class DataGenerator
{
    public static void Seed(ToDoListDbContext dbContext)
    {
        var locale = "pl";

        var userGenerator = new Faker<User>(locale)
            .StrictMode(false)
            .CustomInstantiator(f =>
                new User(f.Random.Guid(), f.Person.Email, f.Person.UserName, "temporary", "user", DateTime.UtcNow));

        var users = userGenerator.Generate(10);

        var categoryGenerator = new Faker<Category>(locale)
            .StrictMode(false)
            .CustomInstantiator(f =>
                new Category(f.Random.Guid(), f.Commerce.ProductName(), f.Lorem.Word(), f.PickRandom(users).Id));

        var categories = categoryGenerator.Generate(50);

        var taskGenerator = new Faker<Tasks>()
            .StrictMode(false)
            .CustomInstantiator(f =>
                new Tasks(f.Random.Guid(), f.Lorem.Word(), f.PickRandom(categories).Id, f.PickRandom(users).Id));

        var tasks = taskGenerator.Generate(500);

        dbContext.AddRange(users);
        dbContext.AddRange(categories);
        dbContext.AddRange(tasks);
        dbContext.SaveChanges();

    }
}