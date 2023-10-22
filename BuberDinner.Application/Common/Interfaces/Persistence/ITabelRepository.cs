


using SmartRMS.Domain.Models;
using SS_RMS.Domain.Entities;

namespace SmartRMS.Application.Common.Interfaces.Persistence;

    public interface ITabelRepository
{
    MasTabel? Get(string recordID);
    MasTabelView? GetView(string recordID);


    MasTabel? Add(Tabels user);

    List<MasTabelView>? GetAll();
    public bool? Delete(string recordID, string userID);
}

