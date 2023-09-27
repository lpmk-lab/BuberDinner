

namespace SS_RMS.Infrastructure.Authentication
{
    public class JwtSetting
    {
        public const string SectionName = "JwtSettings";
        public string Secret { get; init; } = null!;
        public string Issuer { get; init; } = null!;
        public int ExpirationMinutes { get; init; }

        public string Audience { get; init; } = null!;
    }
}
