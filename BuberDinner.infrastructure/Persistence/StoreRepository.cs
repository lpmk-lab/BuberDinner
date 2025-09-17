using SmartRMS.Application.Common.Interfaces.Persistence;
using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRMS.Infrastructure.Persistence
{
    public class StoreRepository : IStoreRepository
    {
        private readonly Smart_RMSContext _DBContext;

        public StoreRepository(Smart_RMSContext DBContext)
        {
            _DBContext = DBContext;
        }

        public MasStore? Add(StoreRecord record)
        {
            MasStore NewRecord = new MasStore();
            NewRecord = Get(record.StoreId.ToString());
            if (NewRecord == null)
            {
                NewRecord = new MasStore
                {
                    StoreId = Guid.NewGuid().ToString(),
                    Active = true,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,



                };
                _DBContext.MasStore.Add(NewRecord);
            }

            NewRecord.StoreName = record.StoreName;

            NewRecord.Location = record.Location;
            NewRecord.PhoneNumber = record.PhoneNumber;
            NewRecord.Email = record.Email;
            NewRecord.ManagerName = record.ManagerName;
            NewRecord.IsSaleStore = record.IsSaleStore;
            NewRecord.CreatedBy = record.RequestID;
            NewRecord.ModifiedOn = DateTime.Now;
            NewRecord.ModifiedBy = record.RequestID;


            _DBContext.SaveChanges();

            return NewRecord;
        }

        public bool? Delete(string recordID, string userID)
        {
            MasStore NewRecord = new MasStore();
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

        public MasStore? Get(string recordID)
        {
            MasStore the_Record = _DBContext.MasStore.Where(x => x.StoreId == recordID && x.Active == true).FirstOrDefault();
            return the_Record;
        }

        public List<MasStoreView>? GetAll()
        {
            List<MasStoreView> the_Record = _DBContext.MasStoreView.Where(x => x.Active == true).ToList();
            return the_Record;
        }

        public MasStoreView? GetView(string recordID)
        {
            MasStoreView the_Record = _DBContext.MasStoreView.Where(x => x.StoreId == recordID && x.Active == true).FirstOrDefault();
            return the_Record;
        }
    }
}
