namespace SS_RMS.Contracts.Authentication;

public record LoginRequest(
    string Email,
    string Password
);