using SS_RMS.Application.Common.Errors;
using FluentResults;

namespace SS_RMS.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Login(string Email,string Password);
    Result<AuthenticationResult> Register(string FirstName,string LastName,string Email,string Password);

}