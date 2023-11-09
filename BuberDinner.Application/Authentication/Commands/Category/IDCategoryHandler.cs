

using ErrorOr;
using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;


namespace SmartRMS.Application.Authentication.Commands.Category;

    public interface IDCategoryHandler
    {
    public ErrorOr<List<MasCategoryView>> GetAll();
    public ErrorOr<MasCategoryView> Get(string ID);
    public ErrorOr<MasCategory> Save(Categories record);
    public ErrorOr<bool> Delete(string ID, string requestID);
}

