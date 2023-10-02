using SS_RMS.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using SmartRMS.Api.Controllers;
using SmartRMS.Domain.Common.Errors;

using MediatR;
using SmartRMS.Application.Authentication.Commands.Register;
using SmartRMS.Application.Authentication.Commands.Commons;
using SmartRMS.Application.Authentication.Commands.Login;

namespace SS_RMS.Api.Controllers;


[Route("auth")]
 public class AuthenticationController : ApiController
 {


    
    public readonly ISender _mediator;

    public AuthenticationController(ISender mediator)
    {
        _mediator=mediator;
    }


    [HttpPost("register")]
    public async Task<IActionResult>  Register(RegisterRequest request){

        var command = new RegisterCommand(request.FirstName,
            request.LastName,
            request.Email,
            request.Password);
        ErrorOr<AuthenticationResult> authResult=await _mediator.Send(command); 
        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
            );


    }


    [HttpPost("login")]
    public async Task<IActionResult>  Login(LoginRequest request){
      
           
        var query= new LoginQuery(
            request.Email,
            request.Password
        );
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);
        if (authResult.IsError && authResult.FirstError==Errors.Authentication.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
        }
        return authResult.Match(
           authResult => Ok(MapAuthResult(authResult)),
           errors => Problem(errors)
           );

    }

    #region Extract (MapAuthResult)

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
    #endregion

}

