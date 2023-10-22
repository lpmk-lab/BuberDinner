


using ErrorOr;
using SmartRMS.Domain.Models;
using SS_RMS.Domain.Entities;

namespace SmartRMS.Application.Authentication.Commands.Tabel;

    public interface IDTabelHandler
    {
    public ErrorOr<List<MasTabelView>> GetAll();
    public ErrorOr<MasTabelView> Get(string ID);
    public ErrorOr<MasTabel> Save(Tabels record);
    public ErrorOr<bool> Delete(string ID,string requestID);
    }

