

namespace SmartRMS.Infrastructure.Authentication
{
    public class EncryptionSettings
    {
        public const string SectionName = "Encryption";
        public string Key { get; init; } = null!;
     
    }
}
