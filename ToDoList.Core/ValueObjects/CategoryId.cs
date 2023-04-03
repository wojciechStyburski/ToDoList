namespace ToDoList.Core.ValueObjects;

public sealed record CategoryId
{
    public Guid Value { get; }

    public CategoryId(Guid value)
    {
        if (value == Guid.Empty)
            throw new InvalidEntityIdException(value);

        Value = value;
    }

    public static implicit operator Guid(CategoryId data) => data.Value;
    public static implicit operator CategoryId(Guid value) => new(value);
}