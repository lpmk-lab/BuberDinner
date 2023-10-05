

using FluentValidation;

namespace SmartRMS.Application.Authentication.Commands.Login;

    public class LoginQueryValidator:AbstractValidator<LoginQuery>
    {
    public LoginQueryValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();

    }
}

