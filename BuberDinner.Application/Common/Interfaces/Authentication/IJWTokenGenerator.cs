using SmartRMS.Domain.Models;
using SS_RMS.Domain.Entities;

namespace SS_RMS.Application.Common.Interfaces.Authentication;

public interface IJWTokenGenerator
{

  string GenerateToken(SysUser user);
}