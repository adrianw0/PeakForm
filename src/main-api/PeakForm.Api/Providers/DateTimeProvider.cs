using Core.Interfaces.Providers;

namespace PeakForm.Api.Providers;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;
}
