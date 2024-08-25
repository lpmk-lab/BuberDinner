

using ErrorOr;
using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;

namespace SmartRMS.Application.Authentication.Commands.MenuUnit
{
    public interface IMenuUnitHandler
    {
        public ErrorOr<List<MasMenuUnitView>> GetAll(string MenuID);
        public ErrorOr<MasMenuUnitView> Get(string ID);
        public ErrorOr<MasMenuUnit> Save(MenuUnitRecord record);
        public ErrorOr<bool> Delete(string ID, string requestID);

    }
}
