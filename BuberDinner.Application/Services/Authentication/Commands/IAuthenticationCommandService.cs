
using ErrorOr;
using SmartRMS.Application.Services.Authentication.Commons;

namespace SmartRMS.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
  
    ErrorOr<AuthenticationResult> Register(string FirstName, string LastName, string Email, string Password);

}