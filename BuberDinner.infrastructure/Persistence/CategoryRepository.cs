
using SmartRMS.Application.Common.Interfaces.Persistence;
using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;
using SS_RMS.Domain.Entities;

namespace SmartRMS.Infrastructure.Persistence;

    internal class CategoryRepository:ICategoryRepository
    {
    private readonly Smart_RMSContext _DBContext;

    public CategoryRepository(Smart_RMSContext DBContext)
    {
        _DBContext = DBContext;
    }
    public MasCategory? Add(Categories record)
    {
        MasCategory NewRecord = new MasCategory();
        NewRecord = Get(record.CategoryId.ToString());
        if (NewRecord == null)
        {
            NewRecord = new MasCategory
            {
                CategoryId = Guid.NewGuid().ToString(),
                Active = true,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,



            };
            _DBContext.MasCategory.Add(NewRecord);
        }

        NewRecord.CategoryName = record.CategoryName;

        NewRecord.CategoryIcon = record.CategoryIcon;
    
        NewRecord.CreatedBy = record.RequestID;
        NewRecord.ModifiedOn = DateTime.Now;
        NewRecord.ModifiedBy = record.RequestID;
      

        _DBContext.SaveChanges();

        return NewRecord;
    }

    public bool? Delete(string recordID, string userID)
    {
        MasCategory NewRecord = new MasCategory();
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

    public List<MasCategoryView>? GetAll()
    {
        List<MasCategoryView> the_Record = _DBContext.MasCategoryView.Where(x => x.Active == true).ToList();
        return the_Record;
    }

    public MasCategory? Get(string recordID)
    {
        MasCategory the_Record = _DBContext.MasCategory.Where(x => x.CategoryId == recordID && x.Active == true).FirstOrDefault();
        return the_Record;
    }

    public MasCategoryView? GetView(string recordID)
    {
        MasCategoryView the_Record = _DBContext.MasCategoryView.Where(x => x.CategoryId == recordID && x.Active == true).FirstOrDefault();
        return the_Record;
    }
}

