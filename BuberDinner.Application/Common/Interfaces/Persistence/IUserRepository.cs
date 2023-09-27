





using SS_RMS.Domain.Entities;

namespace SS_RMS.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {

        User? GetUserByEmail(string email);

        void AddUser(User user);


    }
}
