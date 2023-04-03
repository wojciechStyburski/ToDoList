namespace ToDoList.Core.ValueObjects;

public sealed record TaskId
{
    public Guid Value { get; }
    public TaskId(Guid value)
    {
        if (value == Guid.Empty)
            throw new InvalidEntityIdException(value);

        Value = value;
    }

    public static implicit operator Guid(TaskId data) => data.Value;
    public static implicit operator TaskId(Guid value) => new(value);
}