using ErrorOr;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRMS.Application.Authentication.Commands.Store;
using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;

namespace SmartRMS.Api.Controllers
{
    [Route("master/stores")]
    [Authorize]
    public class StoreController : ApiController
    {
        public readonly IStoreHandler _handler;
        public readonly IMapper _mapper;

        public StoreController(IMapper mapper, IStoreHandler handler)
        {


            _mapper = mapper;
            _handler = handler;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {


            ErrorOr<List<MasStoreView>> returnValue = _handler.GetAll();

            return returnValue.Match(
            returnValue => Ok(_mapper.Map<List<StoreView>>(returnValue)),
            errors => Problem(errors)
         );
        }
        [HttpGet("get/{id}")]
        public IActionResult Get(string id)
        {


            ErrorOr<MasStoreView> returnValue = _handler.Get(id);

            return returnValue.Match(
            returnValue => Ok(_mapper.Map<StoreView>(returnValue)),
            errors => Problem(errors)
         );
        }
        [HttpDelete("delete/{id}/{requestID}")]
        public IActionResult Delete(string id, string requestID)
        {


            ErrorOr<bool> returnValue = _handler.Delete(id, requestID);


            return returnValue.Match(
            returnValue => Accepted("Delete Successfully"),
            errors => Problem(errors)
         );
        }

        [HttpPost("Save")]
        public IActionResult Save(StoreRequest recordObj)
        {
            var command = _mapper.Map<StoreRecord>(recordObj);

            ErrorOr<MasStore> returnValue = _handler.Save(command);


            return returnValue.Match(
            returnValue => Ok(_mapper.Map<MasStore>(returnValue)),
            errors => Problem(errors)
         );
        }
    }
}