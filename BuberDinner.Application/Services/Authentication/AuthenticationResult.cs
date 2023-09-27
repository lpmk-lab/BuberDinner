using SS_RMS.Domain.Entities;

namespace SS_RMS.Application.Services.Authentication;

public record AuthenticationResult(
    User user,
    string Token
);