

using SmartRMS.Domain.ModelSignOn;

namespace SmartRMS.Application.Authentication.Commands.Commons;

public record AuthenticationResult(
    SysUser user,
    string Token
);