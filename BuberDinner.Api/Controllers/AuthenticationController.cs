using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace  BuberDinner.Api.Controllers;

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

        var authResult=_IAuthenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );
        var response= new AuthenticationResult(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
              authResult.Token
        );
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult  Login(LoginRequest request){
      
           
        var authResult=_IAuthenticationService.Login(
            request.Email,
            request.Password
        );
        var response= new AuthenticationResult(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
              authResult.Token
        );
         return Ok(response);
    

    }

 }

