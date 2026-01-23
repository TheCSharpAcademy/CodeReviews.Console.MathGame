using System.Globalization;

namespace MathGame.Utils
{
    public static class TimeSpanExtensions
    {
        public static string ToMinutesSeconds(this TimeSpan time)
        {
            return time.ToString("mm':'ss");
        }
    }
}
