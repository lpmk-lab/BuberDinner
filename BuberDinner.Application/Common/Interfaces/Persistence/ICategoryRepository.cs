

using SmartRMS.Domain.Entities;
using SmartRMS.Domain.Models;
using SS_RMS.Domain.Entities;

namespace SmartRMS.Application.Common.Interfaces.Persistence;

    public interface ICategoryRepository
    {
    MasCategory? Get(string recordID);
    MasCategoryView? GetView(string recordID);


    MasCategory? Add(Categories user);

    List<MasCategoryView>? GetAll();
    public bool? Delete(string recordID, string userID);
}

