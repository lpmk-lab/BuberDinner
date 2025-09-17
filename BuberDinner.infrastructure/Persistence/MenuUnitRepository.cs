using SmartRMS.Application.Common.Interfaces.Persistence;
using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;


namespace SmartRMS.Infrastructure.Persistence
{
    internal class MenuUnitRepository : IMenuUnitRepository
    {
        private readonly Smart_RMSContext _DBContext;
        public MenuUnitRepository(Smart_RMSContext DBContext) {
            _DBContext = DBContext;
        }
        public MasMenuUnit? Add(MenuUnitRecord record)
        {
            MasMenuUnit NewRecord = new MasMenuUnit();
            NewRecord = Get(record.UnitId.ToString());
            if (NewRecord == null)
            {
                NewRecord = new MasMenuUnit
                {
                    UnitId = Guid.NewGuid().ToString(),
                    Active = true,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                };
                _DBContext.MasMenuUnit.Add(NewRecord);
            }

            NewRecord.UnitLabel = record.UnitLabel;


            NewRecord.Barcode = record.Barcode;
            NewRecord.MenuId = record.MenuId;
            NewRecord.Qrcode = record.Qrcode;
            NewRecord.ItLowerUnit = record.ItLowerUnit == "true" ? true : false;
    
            decimal price = 0;
            decimal.TryParse(record.Price, out price);
            NewRecord.Price = price;     
            decimal ConvertQTY = 0;
            decimal.TryParse(record.ConvertQty, out ConvertQTY);
            NewRecord.ConvertQty = ConvertQTY;


            NewRecord.CreatedBy = record.RequestID;
            NewRecord.ModifiedOn = DateTime.Now;
            NewRecord.ModifiedBy = record.RequestID;


            _DBContext.SaveChanges();

            return NewRecord;
        }

        public bool? Delete(string recordID, string userID)
        {
            MasMenuUnit NewRecord = new MasMenuUnit();
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

        public List<MasMenuUnitView>? GetAll(string menuID)
        {
            List<MasMenuUnitView> the_Record = _DBContext.MasMenuUnitView.Where(x => x.MenuId==menuID && x.Active == true).ToList();
            return the_Record;
        }

        public MasMenuUnit? Get(string recordID)
        {
            MasMenuUnit the_Record = _DBContext.MasMenuUnit.Where(x => x.UnitId == recordID && x.Active == true).FirstOrDefault();
            return the_Record;
        }

        public MasMenuUnitView? GetView(string recordID)
        {
            MasMenuUnitView the_Record = _DBContext.MasMenuUnitView.Where(x => x.MenuId == recordID && x.Active == true).FirstOrDefault();
            return the_Record;
        }
       
    }
}
