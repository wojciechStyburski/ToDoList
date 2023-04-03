namespace ToDoList.Infrastructure.Configurations;

public class ApplicationSieveProcessor : SieveProcessor
{
    public ApplicationSieveProcessor(IOptions<SieveOptions> options) : base(options) { }

    protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
    {
        mapper.Property<Tasks>(t => t.TaskName).CanSort().CanFilter();
        mapper.Property<Tasks>(t => t.IsCompleted).CanSort().CanFilter();
        mapper.Property<Tasks>(t => t.CreatedAt).CanSort().CanFilter();

        return mapper;
    }
}