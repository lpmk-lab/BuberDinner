using ErrorOr;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRMS.Application.Authentication.Commands.Customer;
using SmartRMS.Contracts.Authentication;
using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;

namespace SmartRMS.Api.Controllers
{
    [Route("master/customers")]
    [Authorize]
    public class CustomerController :ApiController
    { 
     public readonly ICustomerHandler _ICustomerHandler;
    public readonly IMapper _mapper;

    public CustomerController(IMapper mapper, ICustomerHandler ICustomerHandler)
    {


        _mapper = mapper;
        _ICustomerHandler = ICustomerHandler;
    }

    [HttpGet("getAll")]
    public IActionResult GetAll()
    {


        ErrorOr<List<MasCustomerView>> returnValue = _ICustomerHandler.GetAll();

        return returnValue.Match(
        returnValue => Ok(_mapper.Map<List<CustomerView>>(returnValue)),
        errors => Problem(errors)
     );
    }
    [HttpGet("get/{id}")]
    public IActionResult Get(string id)
    {


        ErrorOr<MasCustomerView> returnValue = _ICustomerHandler.Get(id);

        return returnValue.Match(
        returnValue => Ok(_mapper.Map<CustomerView>(returnValue)),
        errors => Problem(errors)
     );
    }
    [HttpDelete("delete/{id}/{requestID}")]
    public IActionResult Delete(string id, string requestID)
    {


        ErrorOr<bool> returnValue = _ICustomerHandler.Delete(id, requestID);


        return returnValue.Match(
        returnValue => Accepted("Delete Successfully"),
        errors => Problem(errors)
     );
    }

    [HttpPost("Save")]
    public IActionResult Save(CustomerRequest recordObj)
    {
        var command = _mapper.Map<CustomerRecord>(recordObj);

        ErrorOr<MasCustomer> returnValue = _ICustomerHandler.Save(command);


        return returnValue.Match(
        returnValue => Ok(_mapper.Map<MasCustomer>(returnValue)),
        errors => Problem(errors)
     );
    }
}
}
