using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{


    private readonly IJWTokenGenerator _IJWTokenGenerator;
    public AuthenticationService(IJWTokenGenerator IJWTokenGenerator)
    {
          _IJWTokenGenerator=IJWTokenGenerator;
    }
    public AuthenticationResult Login(string Email, string Password)
    {
      
        return new AuthenticationResult(
            Guid.NewGuid(),
            "FirstName",
            "LastName",
            Email,
            "Token"
            );
     }

    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
    {
      
      //Check if User Already Exist

      //Create User(Generate Unique GUID) 

      //Create  JWtoken
      Guid userId=Guid.NewGuid();
      var token=_IJWTokenGenerator.GenerateToken(userId,FirstName,LastName);

          return new AuthenticationResult(
            Guid.NewGuid(),
            FirstName,
            LastName,
            Email,
             token
            );
    }
}
