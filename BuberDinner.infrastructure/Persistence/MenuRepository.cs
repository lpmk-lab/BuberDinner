using SmartRMS.Application.Common.Interfaces;
using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;


namespace SmartRMS.Infrastructure.Persistence;

    internal class MenuRepository:IMenuRepository
    {
        private readonly Smart_RMSContext _DBContext;

        public MenuRepository(Smart_RMSContext DBContext)
        {
            _DBContext = DBContext;
        }
        public MasMenu? Add(MenuRecord record)
        {
            MasMenu NewRecord = new MasMenu();
            NewRecord = Get(record.MenuId.ToString());
            if (NewRecord == null)
            {
                NewRecord = new MasMenu
                {
                    MenuId = Guid.NewGuid().ToString(),
                    Active = true,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,



                };
                _DBContext.MasMenu.Add(NewRecord);
            }

            NewRecord.MenuCode = record.MenuCode;

            NewRecord.MenuName = record.MenuName;
            NewRecord.PhotoUrl = record.PhotoURL;
            NewRecord.CategoryId = record.CategoryID;
            NewRecord.IsNeedCook = record.isNeedCook == "true" ? true:false ;
            NewRecord.IsSubMenuId = record.isSubMenuID == "true" ? true:false ;
            decimal cookingTime = 0;
            decimal.TryParse(record.CookingTime,out cookingTime);
            NewRecord.CookingTime= cookingTime;


            NewRecord.CreatedBy = record.RequestID;
            NewRecord.ModifiedOn = DateTime.Now;
            NewRecord.ModifiedBy = record.RequestID;


            _DBContext.SaveChanges();

            return NewRecord;
        }

        public bool? Delete(string recordID, string userID)
        {
            MasMenu NewRecord = new MasMenu();
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

        public List<MasMenuView>? GetAll()
        {
            List<MasMenuView> the_Record = _DBContext.MasMenuView.Where(x => x.Active == true).ToList();
            return the_Record;
        }

        public MasMenu? Get(string recordID)
        {
            MasMenu the_Record = _DBContext.MasMenu.Where(x => x.MenuId == recordID && x.Active == true).FirstOrDefault();
            return the_Record;
        }

        public MasMenuView? GetView(string recordID)
        {
            MasMenuView the_Record = _DBContext.MasMenuView.Where(x => x.MenuId == recordID && x.Active == true).FirstOrDefault();
            return the_Record;
        }
    }

