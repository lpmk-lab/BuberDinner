using SS_RMS.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using SmartRMS.Api.Controllers;
using SmartRMS.Domain.Common.Errors;

using MediatR;
using SmartRMS.Application.Authentication.Commands.Register;
using SmartRMS.Application.Authentication.Commands.Commons;
using SmartRMS.Application.Authentication.Commands.Login;
using MapsterMapper;

namespace SS_RMS.Api.Controllers;


[Route("auth")]
 public class AuthenticationController : ApiController
 {


    
    public readonly ISender _mediator;
    public readonly IMapper _mapper;

    public AuthenticationController(ISender mediator,IMapper mapper)
    {
        _mediator=mediator;
        _mapper = mapper;
    }


    [HttpPost("register")]
    public async Task<IActionResult>  Register(RegisterRequest request){

        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> authResult=await _mediator.Send(command); 
        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors)
            );


    }


    [HttpPost("login")]
    public async Task<IActionResult>  Login(LoginRequest request){
      
           
        var query= _mapper.Map<LoginQuery>(request);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);
        if (authResult.IsError && authResult.FirstError==Errors.Authentication.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
        }
        return authResult.Match(
           authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
           errors => Problem(errors)
           );

    }

   

}

