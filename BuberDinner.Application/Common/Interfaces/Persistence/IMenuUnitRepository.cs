
using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;

namespace SmartRMS.Application.Common.Interfaces.Persistence
{
    public interface IMenuUnitRepository
    {

        MasMenuUnit? Get(string recordID);
        MasMenuUnitView? GetView(string recordID);


        MasMenuUnit? Add(MenuUnitRecord data);
      

        List<MasMenuUnitView>? GetAll(string menuID);
        public bool? Delete(string recordID, string userID);
    }
}
