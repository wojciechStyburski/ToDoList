namespace ToDoList.Infrastructure.DataAccessLayer.Configurations;

public class TaskConfiguration : IEntityTypeConfiguration<Tasks>
{
    public void Configure(EntityTypeBuilder<Tasks> builder)
    {
        builder
            .HasKey(x => x.Id);
        builder
            .Property(x => x.Id)
            .HasConversion(x => x.Value, x => new TaskId(x));

        builder
            .HasIndex(x => x.TaskName);
        builder
            .Property(x => x.TaskName)
            .HasConversion(x => x.Value, x => new TaskName(x))
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .HasOne(x => x.Category)
            .WithMany(c => c.ListOfTask)
            .HasForeignKey(x => x.CategoryId);
        builder
            .Property(x => x.CategoryId)
            .IsRequired()
            .HasConversion(x => x.Value, x => new CategoryId(x));

        builder
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.ClientCascade);
        builder
            .Property(x => x.UserId)
            .IsRequired()
            .HasConversion(x => x.Value, x => new UserId(x));

        builder
            .Property(x => x.CreatedAt)
            .IsRequired();

        builder
            .Property(x => x.UpdatedAt)
            .IsRequired();
    }
}