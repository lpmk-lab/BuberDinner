using ErrorOr;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRMS.Application.Authentication.Commands.Menu;

using SmartRMS.Contracts.Authentication;
using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;
using SS_RMS.Domain.Entities;

namespace SmartRMS.Api.Controllers
{
    [Route("master/Menu")]
    [Authorize]
    public class MenuController : ApiController
    {
        public readonly IMenuHandler _IDMenuHandler;
        public readonly IMapper _mapper;

        public MenuController(IMapper mapper, IMenuHandler IDMenuHandler)
        {


            _mapper = mapper;
            _IDMenuHandler = IDMenuHandler;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {


            ErrorOr<List<MasMenuView>> returnValue = _IDMenuHandler.GetAll();

            return returnValue.Match(
            returnValue => Ok(_mapper.Map<List<MenuView>>(returnValue)),
            errors => Problem(errors)
         );
        }
        [HttpGet("get/{id}")]
        public IActionResult Get(string id)
        {


            ErrorOr<MasMenuView> returnValue = _IDMenuHandler.Get(id);

            return returnValue.Match(
            returnValue => Ok(_mapper.Map<MenuView>(returnValue)),
            errors => Problem(errors)
         );
        }
        [HttpDelete("delete/{id}/{requestID}")]
        public IActionResult Delete(string id, string requestID)
        {


            ErrorOr<bool> returnValue = _IDMenuHandler.Delete(id, requestID);


            return returnValue.Match(
            returnValue => Accepted("Delete Successfully"),
            errors => Problem(errors)
         );
        }

        [HttpPost("Save")]
        public IActionResult Save(MenuRequest recordObj)
        {
            var command = _mapper.Map<MenuRecord>(recordObj);

            ErrorOr<MasMenu> returnValue = _IDMenuHandler.Save(command);


            return returnValue.Match(
            returnValue => Ok(_mapper.Map<MasMenu>(returnValue)),
            errors => Problem(errors)
         );
        }

    }
}
