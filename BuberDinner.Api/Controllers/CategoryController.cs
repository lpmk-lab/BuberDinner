using ErrorOr;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRMS.Application.Authentication.Commands.Category;
using SmartRMS.Contracts.Authentication;
using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;


namespace SmartRMS.Api.Controllers;

[Route("master/categorys")]
[Authorize]
public class CategoryController: ApiController
    {

    public readonly IDCategoryHandler _IDCatagoryHandler;
    public readonly IMapper _mapper;

    public CategoryController(IMapper mapper, IDCategoryHandler IDCatagoryHandler)
    {


        _mapper = mapper;
        _IDCatagoryHandler = IDCatagoryHandler;
    }

    [HttpGet("getAll")]
    public IActionResult GetAll()
    {


        ErrorOr<List<MasCategoryView>> returnValue = _IDCatagoryHandler.GetAll();

        return returnValue.Match(
        returnValue => Ok(_mapper.Map<List<CategoriesView>>(returnValue)),
        errors => Problem(errors)
     );
    }
    [HttpGet("get/{id}")]
    public IActionResult Get(string id)
    {


        ErrorOr<MasCategoryView> returnValue = _IDCatagoryHandler.Get(id);

        return returnValue.Match(
        returnValue => Ok(_mapper.Map<CategoriesView>(returnValue)),
        errors => Problem(errors)
     );
    }
    [HttpDelete("delete/{id}/{requestID}")]
    public IActionResult Delete(string id, string requestID)
    {


        ErrorOr<bool> returnValue = _IDCatagoryHandler.Delete(id, requestID);


        return returnValue.Match(
        returnValue => Accepted("Delete Successfully"),
        errors => Problem(errors)
     );
    }

    [HttpPost("Save")]
    public IActionResult Save(CategoryRequest recordObj)
    {
        var command = _mapper.Map<Categories>(recordObj);

        ErrorOr<MasCategory> returnValue = _IDCatagoryHandler.Save(command);


        return returnValue.Match(
        returnValue => Ok(_mapper.Map<MasCategory>(returnValue)),
        errors => Problem(errors)
     );
    }
}

