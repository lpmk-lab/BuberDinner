

using ErrorOr;
using SmartRMS.Application.Common.Interfaces.Persistence;
using SmartRMS.Domain.Models;
using SmartRMS.Domain.Common.Errors;
using Azure.Core;
using SS_RMS.Domain.Entities;

namespace SmartRMS.Application.Authentication.Commands.Tabel;

public class TabelHandler : IDTabelHandler 
{
    private readonly ITabelRepository _ITabelRepository;
    public TabelHandler(ITabelRepository ITabelRepository)
    {
        _ITabelRepository = ITabelRepository;
    }
    public ErrorOr<bool> Delete(string ID,string requestID)
    {
        var isSuccess = _ITabelRepository.Delete(ID,requestID);
        if (isSuccess == true)
        {
            return true;
        }
        else
        {
            return CommonErrors.Delete.RecordNotFound;
        }
    }

    public ErrorOr<MasTabelView> Get(string ID)
    {
        MasTabelView record = _ITabelRepository.GetView(ID);
        if(record == null)
        {
            return CommonErrors.Delete.RecordNotFound;
        
        }
        else
        {
            return record;
        }
    }

    public ErrorOr<List<MasTabelView>> GetAll()
    {
        return _ITabelRepository.GetAll();
    }

    public ErrorOr<MasTabel> Save(Tabels record)
    {
        return _ITabelRepository.Add(record);
    }
}
