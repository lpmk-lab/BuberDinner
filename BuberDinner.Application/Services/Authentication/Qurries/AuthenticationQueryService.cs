using ErrorOr;
using SS_RMS.Application.Common.Interfaces.Authentication;
using SS_RMS.Application.Common.Interfaces.Persistence;
using SmartRMS.Domain.Common.Errors;
using SS_RMS.Domain.Entities;
using SmartRMS.Application.Services.Authentication.Commons;

namespace SmartRMS.Application.Services.Authentication.Qurries
{
    public class AuthenticationQueryService:IAuthenticationQueryService
    {
        private readonly IJWTokenGenerator _IJWTokenGenerator;
        private readonly IUserRepository _IUserRepository;
        public AuthenticationQueryService(IJWTokenGenerator IJWTokenGenerator, IUserRepository IUserRepository)
        {
            _IJWTokenGenerator = IJWTokenGenerator;
            _IUserRepository = IUserRepository;
        }

        public ErrorOr<AuthenticationResult> Login(string Email, string Password)
        {
            //1 Validate User Exit
            if (_IUserRepository.GetUserByEmail(Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            //2 Validate Password Is Correct
            if (user.Password != Password)
            {
                return new[] { Errors.Authentication.InvalidCredentials };

            }
            //3 Create Token
            var token = _IJWTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token
                );
        }
    }
}
