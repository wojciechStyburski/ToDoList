namespace ToDoList.Core.ValueObjects;

public sealed record CategoryName
{
    public string Value { get; }

    public CategoryName(string value)
    {
        if (string.IsNullOrEmpty(value) || value.Length > 50)
            throw new InvalidCategoryNameException(value);

        Value = value;
    }

    public static implicit operator string(CategoryName name) => name.Value;
    public static implicit operator CategoryName(string value) => new(value);
}