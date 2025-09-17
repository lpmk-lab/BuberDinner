using ErrorOr;
using SmartRMS.Application.Common.Interfaces.Persistence;
using SmartRMS.Domain.Common.Errors;
using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;

namespace SmartRMS.Application.Authentication.Commands.Store
{
    public class StoreHandler : IStoreHandler
    {
        private readonly IStoreRepository _repository;
        public StoreHandler(IStoreRepository repository)
        {
            _repository = repository;
        }
        public ErrorOr<bool> Delete(string ID, string requestID)
        {
            var isSuccess = _repository.Delete(ID, requestID);
            if (isSuccess == true)
            {
                return true;
            }
            else
            {
                return CommonErrors.Delete.RecordNotFound;
            }
        }

        public ErrorOr<MasStoreView> Get(string ID)
        {
            MasStoreView record = _repository.GetView(ID);
            if (record == null)
            {
                return CommonErrors.Delete.RecordNotFound;

            }
            else
            {
                return record;
            }
        }

        public ErrorOr<List<MasStoreView>> GetAll()
        {
            return _repository.GetAll();
        }

        public ErrorOr<MasStore> Save(StoreRecord record)
        {
            return _repository.Add(record);
        }
    }
}
