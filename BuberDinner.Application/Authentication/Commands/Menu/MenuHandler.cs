
using ErrorOr;
using SmartRMS.Application.Common.Interfaces;
using SmartRMS.Domain.Common.Errors;
using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;

namespace SmartRMS.Application.Authentication.Commands.Menu;
    public class MenuHandler:IMenuHandler
    {
    private readonly IMenuRepository _IMenuRepository;
    public MenuHandler(IMenuRepository IMenuRepository)
    {
        _IMenuRepository = IMenuRepository;
    }
    public ErrorOr<bool> Delete(string ID, string requestID)
    {
        var isSuccess = _IMenuRepository.Delete(ID, requestID);
        if (isSuccess == true)
        {
            return true;
        }
        else
        {
            return CommonErrors.Delete.RecordNotFound;
        }
    }

    public ErrorOr<MasMenuView> Get(string ID)
    {
        MasMenuView record = _IMenuRepository.GetView(ID);
        if (record == null)
        {
            return CommonErrors.Delete.RecordNotFound;

        }
        else
        {
            return record;
        }
    }

    public ErrorOr<List<MasMenuView>> GetAll()
    {
        return _IMenuRepository.GetAll();
    }

    public ErrorOr<MasMenu> Save(MenuRecord record)
    {
        return _IMenuRepository.Add(record);
    }
}

