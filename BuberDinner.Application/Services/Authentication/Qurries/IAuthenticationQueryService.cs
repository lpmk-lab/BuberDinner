using ErrorOr;
using SmartRMS.Application.Services.Authentication.Commons;


namespace SmartRMS.Application.Services.Authentication.Qurries;

public interface IAuthenticationQueryService
    {
        ErrorOr<AuthenticationResult> Login(string Email, string Password);
   }

