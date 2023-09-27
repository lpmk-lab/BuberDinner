using SS_RMS.Application.Common.Errors;
using SS_RMS.Application.Services.Authentication;
using SS_RMS.Contracts.Authentication;
using FluentResults;
using Microsoft.AspNetCore.Mvc;


namespace  SS_RMS.Api.Controllers;

[ApiController]
[Route("auth")]
 public class AuthenticationController : ControllerBase
 {


    private readonly IAuthenticationService _IAuthenticationService;

    public AuthenticationController(IAuthenticationService IAuthenticationService)
    {
        _IAuthenticationService=IAuthenticationService;
    }


    [HttpPost("register")]
    public IActionResult  Register(RegisterRequest request){

        Result<AuthenticationResult> registerResult=_IAuthenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );
        if (registerResult.IsSuccess)
        {
            return Ok(MapAuthResult(registerResult.Value));
        }
        var firstError = registerResult.Errors[0];
        if(firstError is DuplicateEmailError)
        {
            return Problem(statusCode: StatusCodes.Status409Conflict, title: "email is already Used");
        }
        return Problem();
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        
        return new AuthenticationResponse(
           authResult.user.Id,
           authResult.user.FirstName,
           authResult.user.LastName,
           authResult.user.Email,
           authResult.Token
   );
    }

    [HttpPost("login")]
    public IActionResult  Login(LoginRequest request){
      
           
        var authResult=_IAuthenticationService.Login(
            request.Email,
            request.Password
        );
        var response= new AuthenticationResponse(
            authResult.user.Id,
            authResult.user.FirstName,
            authResult.user.LastName,
            authResult.user.Email,
              authResult.Token
        );
         return Ok(response);
    

    }

 }

