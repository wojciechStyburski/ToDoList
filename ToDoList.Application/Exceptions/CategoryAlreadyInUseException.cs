namespace ToDoList.Application.Exceptions;

public class CategoryAlreadyInUseException : CustomException
{
    public string CategoryName { get; }

    public CategoryAlreadyInUseException(string categoryName) 
        : base($"Category with name {categoryName} is already in use") 
        => CategoryName = categoryName;
}