namespace PublicArt.Util.Extensions
{
    public static class StringExtensions
    {
        public static string ShortenIfTooLong(this string value, int maxLength)
        {
            const string suffix = "...";
            if (string.IsNullOrEmpty(value)) return value;

            return value.Length <= maxLength ? value : value.Substring(0, maxLength - suffix.Length) + suffix;
        }
    }
}