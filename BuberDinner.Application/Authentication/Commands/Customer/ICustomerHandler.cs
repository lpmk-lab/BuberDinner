

using ErrorOr;
using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;

namespace SmartRMS.Application.Authentication.Commands.Customer
{
    public interface ICustomerHandler
    {
        public ErrorOr<List<MasCustomerView>> GetAll();
        public ErrorOr<MasCustomerView> Get(string ID);
        public ErrorOr<MasCustomer> Save(CustomerRecord record);
        public ErrorOr<bool> Delete(string ID, string requestID);
    }
}
