
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SmartRMS.Api.Controllers;
    
    [Route("dinners")]
    [Authorize]
    public class DinnerController:ApiController
    {
    [HttpGet]
    public IActionResult ListDinner() 
    { 

        return Ok(Array.Empty<string>());
    }
    }

 