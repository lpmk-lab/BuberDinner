
using SmartRMS.Application.Common.Interfaces.Persistence;
using SmartRMS.Domain.Models;
using SS_RMS.Domain.Entities;

namespace SmartRMS.Infrastructure.Persistence;

internal class TabelRepository : ITabelRepository
{
    private readonly Smart_RMSContext _DBContext;

    public TabelRepository(Smart_RMSContext DBContext)
    {
        _DBContext = DBContext;
    }
    public MasTabel? Add(Tabels record)
    {
        MasTabel NewRecord =new MasTabel();
        NewRecord = Get(record.TableId.ToString());
        if (NewRecord == null)
        {
            NewRecord = new MasTabel
            {
                TableId = Guid.NewGuid().ToString(),
                Active = true,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,



            };
            _DBContext.MasTabel.Add(NewRecord);
        }

        NewRecord.TableName = record.TableName;

        NewRecord.TableNo = record.TableNo;
        NewRecord.Location = record.Location;

        NewRecord.CreatedBy = record.RequestID;
        NewRecord.ModifiedBy = record.RequestID;
        NewRecord.Status = record.Status;
    
        _DBContext.SaveChanges();

        return NewRecord;
    }

    public bool? Delete(string recordID,string userID)
    {
        MasTabel NewRecord = new MasTabel();
        NewRecord = Get(recordID);
        if(NewRecord != null)
        {
            NewRecord.Active=false;
            NewRecord.ModifiedBy= userID;
            NewRecord.ModifiedOn= DateTime.Now;
            _DBContext.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<MasTabelView>? GetAll()
    {
        List<MasTabelView> the_Record = _DBContext.MasTabelView.Where(x=>x.Active==true).ToList();
        return the_Record;
    }

    public MasTabel? Get(string recordID)
    {
        MasTabel the_Record = _DBContext.MasTabel.Where(x => x.TableId == recordID && x.Active == true).FirstOrDefault();
        return the_Record;
    }

    public MasTabelView? GetView(string recordID)
    {
        MasTabelView the_Record = _DBContext.MasTabelView.Where(x => x.TableId == recordID && x.Active==true).FirstOrDefault();
        return the_Record;
    }
}
