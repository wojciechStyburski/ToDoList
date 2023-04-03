namespace ToDoList.Infrastructure.Auth;

public class AuthValidator : IValidateOptions<AuthOptions>
{
    public ValidateOptionsResult Validate(string name, AuthOptions options)
    {
        var validationResult = "";

        if (string.IsNullOrEmpty(options.Issuer))
            validationResult += $"{nameof(options.Issuer)} is missing";
        
        if(string.IsNullOrEmpty(options.Audience))
            validationResult += $"{nameof(options.Audience)} is missing";

        if (string.IsNullOrEmpty(options.SigningKey))
            validationResult += $"{nameof(options.SigningKey)} is missing";

        return !string.IsNullOrEmpty(validationResult) ? ValidateOptionsResult.Fail(validationResult) : ValidateOptionsResult.Success;
    }
}