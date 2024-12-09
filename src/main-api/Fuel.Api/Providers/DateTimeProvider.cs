using Core.Interfaces.Providers;

namespace Fuel.Api.Providers;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;
}
