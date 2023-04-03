namespace ToDoList.Core.Exceptions;

public class InvalidCategoryNameException : CustomException
{
    public string CategoryName { get; }
    public InvalidCategoryNameException(string categoryName) : base($"Category name: {categoryName} is invalid.")
    {
        CategoryName = categoryName;
    }
}