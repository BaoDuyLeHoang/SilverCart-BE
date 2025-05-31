using SilverCart.Application.Interfaces;

namespace SilverCart.Application.Services
{
    public class CurrentTime : ICurrentTime
    {
        public DateTime GetCurrentTime() => DateTime.UtcNow.AddHours(7);
    }
}
