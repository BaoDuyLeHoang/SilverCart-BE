using SilverCart.Application.Interfaces;

namespace SilverCart.Application.Services
{
    public class CurrentTime : ICurrentTime
    {
        private DateTime? _currentTime;
        public DateTime GetCurrentTime()
        {
            //DateTime.UtcNow produce utc time, so we need to add 7 hours to get vietnam time
            _currentTime ??= DateTime.UtcNow.AddHours(7);
            return _currentTime.Value;
        }
    }
}
