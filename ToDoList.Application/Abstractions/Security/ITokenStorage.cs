namespace ToDoList.Application.Abstractions.Security;

public interface ITokenStorage
{
    void Set(JwtDto jwt);
    JwtDto Get();
}