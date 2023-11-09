

using ErrorOr;
using SmartRMS.Application.Common.Interfaces.Persistence;
using SmartRMS.Domain.Common.Errors;
using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;


namespace SmartRMS.Application.Authentication.Commands.Category;
    public class CategoryHandler :IDCategoryHandler
{
    private readonly ICategoryRepository _ICategoryRepository;
    public CategoryHandler(ICategoryRepository ICategoryRepository)
    {
        _ICategoryRepository = ICategoryRepository;
    }
    public ErrorOr<bool> Delete(string ID, string requestID)
    {
        var isSuccess = _ICategoryRepository.Delete(ID, requestID);
        if (isSuccess == true)
        {
            return true;
        }
        else
        {
            return CommonErrors.Delete.RecordNotFound;
        }
    }

    public ErrorOr<MasCategoryView> Get(string ID)
    {
        MasCategoryView record = _ICategoryRepository.GetView(ID);
        if (record == null)
        {
            return CommonErrors.Delete.RecordNotFound;

        }
        else
        {
            return record;
        }
    }

    public ErrorOr<List<MasCategoryView>> GetAll()
    {
        return _ICategoryRepository.GetAll();
    }

    public ErrorOr<MasCategory> Save(Categories record)
    {
        return _ICategoryRepository.Add(record);
    }
}

