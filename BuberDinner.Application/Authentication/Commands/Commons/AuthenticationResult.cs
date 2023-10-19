using SmartRMS.Domain.Models;
using SS_RMS.Domain.Entities;

namespace SmartRMS.Application.Authentication.Commands.Commons;

public record AuthenticationResult(
    SysUser user,
    string Token
);