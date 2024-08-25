
using ErrorOr;
using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;

namespace SmartRMS.Application.Authentication.Commands.Menu;

    public interface IMenuHandler
{
    public ErrorOr<List<MasMenuView>> GetAll();
    public ErrorOr<MasMenuView> Get(string ID);
    public ErrorOr<MasMenu> Save(MenuRecord record);
    public ErrorOr<bool> Delete(string ID, string requestID);
    public ErrorOr<MasMenu> Upload(string FileUrl, string MenuID);
}

