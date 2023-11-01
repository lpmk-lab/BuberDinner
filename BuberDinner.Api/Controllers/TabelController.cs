using Azure.Core;
using ErrorOr;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRMS.Application.Authentication.Commands.Register;
using SmartRMS.Application.Authentication.Commands.Tabel;
using SmartRMS.Contracts.Authentication;
using SmartRMS.Domain.Models;
using SS_RMS.Domain.Entities;

namespace SmartRMS.Api.Controllers
{
    [Route("master/tabels")]
    [Authorize]
    public class TabelController : ApiController
    {
       
        
        public readonly IDTabelHandler _IDTabelHandler;
        public readonly IMapper _mapper;

        public TabelController(IMapper mapper, IDTabelHandler IDTabelHandler)
        {
          

            _mapper = mapper;
            _IDTabelHandler = IDTabelHandler;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {


            ErrorOr<List<MasTabelView>> returnValue = _IDTabelHandler.GetAll();
         
            return returnValue.Match(
            returnValue => Ok(_mapper.Map<List<TabelsView>>(returnValue)),
            errors => Problem(errors)
         );
        }
        [HttpGet("get/{id}")]
        public IActionResult Get(string id)
        {


            ErrorOr<MasTabelView> returnValue = _IDTabelHandler.Get(id);

            return returnValue.Match(
            returnValue => Ok(_mapper.Map<TabelsView>(returnValue)),
            errors => Problem(errors)
         );
        }
        [HttpDelete("delete/{id}/{requestID}")]
        public IActionResult Delete(string id,string requestID)
        {


            ErrorOr<bool> returnValue = _IDTabelHandler.Delete(id, requestID);


            return returnValue.Match(
            returnValue => Accepted("Delete Successfully"),
            errors => Problem(errors)
         );
        }

        [HttpPost("Save")]
        public IActionResult Save(TabelRequest recordObj)
        {
            var command = _mapper.Map<Tabels>(recordObj);

            ErrorOr<MasTabel> returnValue = _IDTabelHandler.Save(command);


            return returnValue.Match(
            returnValue => Ok(_mapper.Map<MasTabel>(returnValue)),
            errors => Problem(errors)
         );
        }

    }
}
