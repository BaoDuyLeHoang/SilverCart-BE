using SilverCart.Application.Interfaces;

namespace SilverCart.Application.Services
{
    public class CurrentTime : ICurrentTime
    {
        private DateTime? _currentTime;
        public DateTime GetCurrentTime()
        {
            // Trả về UTC time để tương thích với PostgreSQL
            _currentTime ??= DateTime.UtcNow;
            return _currentTime.Value;
        }
    }
}
