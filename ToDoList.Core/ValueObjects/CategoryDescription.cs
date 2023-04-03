namespace ToDoList.Core.ValueObjects;

public sealed record CategoryDescription
{
    public string Value { get; }

    public CategoryDescription(string value)
    {
        if (string.IsNullOrEmpty(value) || value.Length > 150)
            throw new InvalidCategoryNameException(value);

        Value = value;
    }

    public static implicit operator string(CategoryDescription name) => name.Value;
    public static implicit operator CategoryDescription(string value) => new(value);
}