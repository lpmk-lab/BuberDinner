

using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;

namespace SmartRMS.Application.Common.Interfaces.Persistence
{
    public interface ICustomerRepository
    {
        MasCustomer? Get(string recordID);
        MasCustomerView? GetView(string recordID);


        MasCustomer? Add(CustomerRecord user);

        List<MasCustomerView>? GetAll();
        public bool? Delete(string recordID, string userID);
    }
}
