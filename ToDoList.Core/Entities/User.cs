namespace ToDoList.Core.Entities;

public class User
{
    public UserId Id { get; }
    public Email Email { get; }
    public UserName UserName { get; }
    public Password Password { get; }
    public Role Role { get; }
    public DateTime CreatedAt { get; }
    public User() { }
    public User(UserId id, Email email, UserName userName, Password password, Role role, DateTime createdAt)
    {
        Id = id;
        Email = email;
        UserName = userName;
        Password = password;
        Role = role;
        CreatedAt = createdAt;
    }
}