using SS_RMS.Domain.Entities;

namespace SmartRMS.Application.Authentication.Commands.Commons;

public record AuthenticationResult(
    User user,
    string Token
);