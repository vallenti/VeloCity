namespace VeloCity.Extensions
{
    public static class StringExtensions
    {
        public static string ToDateString(this DateTime date)
            => date.ToString("dd.MM.yyy HH:mm:ss");
    }
}
