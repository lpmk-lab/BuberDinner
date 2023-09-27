
using SS_RMS.Application.Common.Interfaces.Services;

namespace SS_RMS.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
