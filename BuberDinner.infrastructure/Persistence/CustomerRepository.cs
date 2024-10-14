
using SmartRMS.Application.Common.Interfaces.Persistence;
using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;

namespace SmartRMS.Infrastructure.Persistence
{
    internal class CustomerRepository : ICustomerRepository 
    { 
    private readonly Smart_RMSContext _DBContext;

    public CustomerRepository(Smart_RMSContext DBContext)
    {
        _DBContext = DBContext;
    }
    public MasCustomer? Add(CustomerRecord record)
    {
        MasCustomer NewRecord = new MasCustomer();
        NewRecord = Get(record.CustomerId.ToString());
        if (NewRecord == null)
        {
            NewRecord = new MasCustomer
            {
                CustomerId = Guid.NewGuid().ToString(),
                Active = true,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,



            };
            _DBContext.MasCustomer.Add(NewRecord);
        }

        NewRecord.CustomerName = record.CustomerName;

        NewRecord.PhoneNo = record.PhoneNo;

        NewRecord.CreatedBy = record.RequestID;
        NewRecord.ModifiedOn = DateTime.Now;
        NewRecord.ModifiedBy = record.RequestID;


        _DBContext.SaveChanges();

        return NewRecord;
    }

    public bool? Delete(string recordID, string userID)
    {
        MasCustomer NewRecord = new MasCustomer();
        NewRecord = Get(recordID);
        if (NewRecord != null)
        {
            NewRecord.Active = false;
            NewRecord.ModifiedBy = userID;
            NewRecord.ModifiedOn = DateTime.Now;
            _DBContext.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<MasCustomerView>? GetAll()
    {
        List<MasCustomerView> the_Record = _DBContext.MasCustomerView.Where(x => x.Active == true).ToList();
        return the_Record;
    }

    public MasCustomer? Get(string recordID)
    {
        MasCustomer the_Record = _DBContext.MasCustomer.Where(x => x.CustomerId == recordID && x.Active == true).FirstOrDefault();
        return the_Record;
    }

    public MasCustomerView? GetView(string recordID)
    {
        MasCustomerView the_Record = _DBContext.MasCustomerView.Where(x => x.CustomerId == recordID && x.Active == true).FirstOrDefault();
        return the_Record;
    }
}
}
