namespace ToDoList.Application.Exceptions;

public class CategoryNotFoundException : CustomException
{
    public string CategoryName { get; }

    public CategoryNotFoundException(string categoryName) 
        : base($"Category with name: {categoryName} not found") 
        => CategoryName = categoryName;
}