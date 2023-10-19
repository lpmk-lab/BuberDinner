
using Microsoft.EntityFrameworkCore;
using SmartRMS.Domain.Models;
using SS_RMS.Application.Common.Interfaces.Persistence;
using SS_RMS.Domain.Entities;

namespace SS_RMS.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly Smart_RMS_SignOnContext _DBSigOnContext;

        public UserRepository(Smart_RMS_SignOnContext dBSigOnContext)
        {
            _DBSigOnContext = dBSigOnContext;
        }

        private static readonly List<User> _users=new();
        public SysUser AddUser(SysUser user)
        {
            SysUser User = new SysUser
            {
                UserId = Guid.NewGuid().ToString(),
                Active = true,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                LastLogin = DateTime.Now,


            };
            
            
            User.UserName = user.UserName;

            User.UserCode = user.UserName;
            User.Email = user.Email;
            User.Password = user.Password;
            User.CreatedBy = User.UserId;
            User.ModifiedBy = User.UserId;
            _DBSigOnContext.SysUser.Add(User);
            _DBSigOnContext.SaveChanges();

            return User;

        }

        public SysUser? GetUserByEmail(string email)
        {
           SysUser the_Record= _DBSigOnContext.SysUser.Where(x=> x.Email == email).FirstOrDefault();
            return the_Record;
        }
        public bool? GetUserByEmailCheck(string email)
        {
            var the_Record = _DBSigOnContext.SysUser.Where(x => x.Email == email).FirstOrDefault();
            if(the_Record != null)
            {
                return true;
            }
            return false ;
        }
    }
}
