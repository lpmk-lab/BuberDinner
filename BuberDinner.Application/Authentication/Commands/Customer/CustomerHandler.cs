using ErrorOr;
using SmartRMS.Application.Common.Interfaces.Persistence;
using SmartRMS.Domain.Common.Errors;
using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;


namespace SmartRMS.Application.Authentication.Commands.Customer
{
    public class CustomerHandler:ICustomerHandler
    {
        private readonly ICustomerRepository _ICustomerRepository;
        public CustomerHandler(ICustomerRepository ICustomerRepository)
        {
            _ICustomerRepository = ICustomerRepository;
        }
        public ErrorOr<bool> Delete(string ID, string requestID)
        {
            var isSuccess = _ICustomerRepository.Delete(ID, requestID);
            if (isSuccess == true)
            {
                return true;
            }
            else
            {
                return CommonErrors.Delete.RecordNotFound;
            }
        }

        public ErrorOr<MasCustomerView> Get(string ID)
        {
            MasCustomerView record = _ICustomerRepository.GetView(ID);
            if (record == null)
            {
                return CommonErrors.Delete.RecordNotFound;

            }
            else
            {
                return record;
            }
        }

        public ErrorOr<List<MasCustomerView>> GetAll()
        {
            return _ICustomerRepository.GetAll();
        }

        public ErrorOr<MasCustomer> Save(CustomerRecord record)
        {
            return _ICustomerRepository.Add(record);
        }
    }
}
