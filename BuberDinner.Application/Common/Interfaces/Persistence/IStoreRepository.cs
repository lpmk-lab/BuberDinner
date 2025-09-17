using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;


namespace SmartRMS.Application.Common.Interfaces.Persistence
{
    public interface IStoreRepository
    {
        MasStore? Get(string recordID);
        MasStoreView? GetView(string recordID);

        MasStore? Add(StoreRecord record);

        List<MasStoreView>? GetAll();
        public bool? Delete(string recordID, string userID);
    }
}
