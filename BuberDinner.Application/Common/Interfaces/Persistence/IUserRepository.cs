





using SmartRMS.Domain.Models;
using SS_RMS.Domain.Entities;

namespace SS_RMS.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {

        SysUser? GetUserByEmail(string email);
        bool? GetUserByEmailCheck(string email);

        SysUser? AddUser(SysUser user);


    }
}
