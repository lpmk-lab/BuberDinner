
using SmartRMS.Domain.ModelSignOn;
namespace SS_RMS.Application.Common.Interfaces.Authentication;

public interface IJWTokenGenerator
{

  string GenerateToken(SysUser user);
}