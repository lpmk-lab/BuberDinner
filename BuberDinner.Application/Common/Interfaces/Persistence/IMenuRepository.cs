using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;

namespace SmartRMS.Application.Common.Interfaces;


public interface IMenuRepository
{
    MasMenu? Get(string recordID);
    MasMenuView? GetView(string recordID);


    MasMenu? Add(MenuRecord data);

    List<MasMenuView>? GetAll();
    public bool? Delete(string recordID, string userID);
}
        
