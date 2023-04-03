using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace ToDoList.Core.Entities;

public class Category
{
    public CategoryId Id { get; }
    public CategoryName Name { get; }
    public CategoryDescription Description { get; private set; }
    public UserId UserId { get; }
    public DateTime CreatedDate { get; }
    public DateTime UpdatedDate { get; private set; }
    public virtual List<Tasks> ListOfTask { get; }
    public Category(CategoryId id, CategoryName name, CategoryDescription description, UserId userId)
    {
        Id = id;
        Name = name;
        Description = description;
        UserId = userId;
        CreatedDate = DateTime.UtcNow;
        UpdatedDate = DateTime.UtcNow;
    }

    public void ChangeCategoryDescription(CategoryDescription description)
    {
        Description = description;
        UpdatedDate = DateTime.UtcNow;
    }
}