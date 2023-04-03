namespace ToDoList.Core.ValueObjects;

public sealed record Email
{
    public string Value { get; }

    public Email(string value)
    {
        if (string.IsNullOrEmpty(value) || value.Length is > 200 or < 10)
            throw new InvalidEmailException(value);

        if (!EmailValidator.Validate(value))
            throw new InvalidEmailException(value);

        Value = value;
    }

    public static implicit operator string(Email email) => email.Value;
    public static implicit operator Email(string value) => new(value);
    public override string ToString() => Value;
}