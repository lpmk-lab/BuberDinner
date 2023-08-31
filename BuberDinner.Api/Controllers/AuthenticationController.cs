using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace  BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
 public class AuthenticationController : ControllerBase
 {

    [HttpPost("register")]
    public IActionResult  Register(RegisterRequest request){

        return Ok(request);

    }
 [HttpPost("register2")]
    public IActionResult  Regiswter(){

        return Ok();

    }

    [HttpPost("login")]
    public IActionResult  Login(LoginRequest request){

        return Ok(request);

    }

 }

