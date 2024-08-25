

using ErrorOr;
using SmartRMS.Domain.Common.Errors;
using SmartRMS.Application.Common.Interfaces.Persistence;
using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;

namespace SmartRMS.Application.Authentication.Commands.MenuUnit
{
    public class MenuUnitHandler : IMenuUnitHandler
    {
        private readonly IMenuUnitRepository _IMenuUnitRepository;
        public MenuUnitHandler(IMenuUnitRepository IMenuUnitRepository)
        {
            _IMenuUnitRepository= IMenuUnitRepository;
        }

            public ErrorOr<bool> Delete(string ID, string requestID)
        {
            var isSuccess = _IMenuUnitRepository.Delete(ID, requestID);
            if (isSuccess == true)
            {
                return true;
            }
            else
            {
                return CommonErrors.Delete.RecordNotFound;
            }
        }
  

        public ErrorOr<MasMenuUnitView> Get(string ID)
        {
            MasMenuUnitView record = _IMenuUnitRepository.GetView(ID);
            if (record == null)
            {
                return CommonErrors.Delete.RecordNotFound;

            }
            else
            {
                return record;
            }
        }

        public ErrorOr<List<MasMenuUnitView>> GetAll(string menuID)
        {
            return _IMenuUnitRepository.GetAll(menuID);
        }

        public ErrorOr<MasMenuUnit> Save(MenuUnitRecord record)
        {
            return _IMenuUnitRepository.Add(record);
        }
    }
}
