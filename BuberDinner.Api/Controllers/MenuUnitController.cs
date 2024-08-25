using ErrorOr;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SmartRMS.Application.Authentication.Commands.MenuUnit;
using SmartRMS.Contracts.Authentication;
using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;

namespace SmartRMS.Api.Controllers
{
    [Route("master/MenuUnit")]
    [Authorize]
    public class MenuUnitController:ApiController
    {
        public readonly IMenuUnitHandler _IMenuUnitHandler;
        public readonly IMapper _mapper;

        public MenuUnitController(IMapper mapper, IMenuUnitHandler IDMenuHandler)
        {


            _mapper = mapper;
            _IMenuUnitHandler = IDMenuHandler;
        }

        [HttpGet("getAll/{id}")]
        public IActionResult GetAll(string id)
        {


            ErrorOr<List<MasMenuUnitView>> returnValue = _IMenuUnitHandler.GetAll(id);

            return returnValue.Match(
            returnValue => Ok(_mapper.Map<List<MenuUnitView>>(returnValue)),
            errors => Problem(errors)
         );
        }
        [HttpGet("get/{id}")]
        public IActionResult Get(string id)
        {


            ErrorOr<MasMenuUnitView> returnValue = _IMenuUnitHandler.Get(id);

            return returnValue.Match(
            returnValue => Ok(_mapper.Map<MenuUnitView>(returnValue)),
            errors => Problem(errors)
         );
        }
        [HttpDelete("delete/{id}/{requestID}")]
        public IActionResult Delete(string id, string requestID)
        {


            ErrorOr<bool> returnValue = _IMenuUnitHandler.Delete(id, requestID);


            return returnValue.Match(
            returnValue => Accepted("Delete Successfully"),
            errors => Problem(errors)
         );
        }

        [HttpPost("Save")]
        public IActionResult Save(MenuUnitRequest recordObj)
        {
            var command = _mapper.Map<MenuUnitRecord>(recordObj);

            ErrorOr<MasMenuUnit> returnValue = _IMenuUnitHandler.Save(command);


            return returnValue.Match(
            returnValue => Ok(_mapper.Map<MasMenuUnit>(returnValue)),
            errors => Problem(errors)
         );
        }
    }
}
