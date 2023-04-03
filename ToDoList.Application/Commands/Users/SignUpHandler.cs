namespace ToDoList.Application.Commands.Users;

public class SignUpHandler : ICommandHandler<SignUp>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordManager _passwordManager;

    public SignUpHandler(IUserRepository userRepository, IPasswordManager passwordManager)
    {
        _userRepository = userRepository;
        _passwordManager = passwordManager;
    }

    public async Task HandleAsync(SignUp command)
    {
        var userId = new UserId(command.UserId);
        var email = new Email(command.Email);
        var userName = new UserName(command.UserName);
        var password = new Password(command.Password);
        var role = new Role(command.Role);

        if (await _userRepository.GetByEmailAsync(email) is not null)
            throw new EmailAlreadyInUseException(email);

        if (await _userRepository.GetByUserNameAsync(userName) is not null)
            throw new UsernameAlreadyInUseException(userName);

        var securedPassword = _passwordManager.Secure(password);
        var newUser = new User(userId, email, userName, securedPassword, role, DateTime.UtcNow);
        await _userRepository.AddAsync(newUser);
    }
}