namespace ToDoList.Infrastructure.DataAccessLayer.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder
            .HasKey(x => x.Id);
        builder
            .Property(x => x.Id)
            .HasConversion(x => x.Value, x => new CategoryId(x));

        builder
            .HasIndex(x => x.Name)
            .IsUnique();
        builder
            .Property(x => x.Name)
            .HasConversion(x => x.Value, x => new CategoryName(x))
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(x => x.Description)
            .HasConversion(x => x.Value, x => new CategoryDescription(x));

        builder
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UserId);

        builder
            .Property(x => x.UserId)
            .IsRequired()
            .HasConversion(x => x.Value, x => new UserId(x));

        builder
            .Property(x => x.CreatedDate)
            .IsRequired();

        builder
            .Property(x => x.UpdatedDate)
            .IsRequired();
    }
}