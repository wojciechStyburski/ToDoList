namespace ToDoList.Core.ValueObjects;

public sealed record TaskName
{
    public string Value { get; }

    public TaskName(string value)
    {
        if (string.IsNullOrEmpty(value) || value.Length > 50)
            throw new InvalidUsernameException(value);

        Value = value;
    }

    public static implicit operator string(TaskName value) => value.Value;
    public static implicit operator TaskName(string value) => new(value);
    public override string ToString() => Value;
}