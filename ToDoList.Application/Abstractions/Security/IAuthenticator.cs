namespace ToDoList.Application.Abstractions.Security;

public interface IAuthenticator
{
    JwtDto CreateToken(Guid userId, string role);
}