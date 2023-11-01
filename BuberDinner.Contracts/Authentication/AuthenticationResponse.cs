namespace SS_RMS.Contracts.Authentication;

public record AuthenticationResponse(
    string UserID,
    string UserName,
    string Email,
    string Token
);