using System;

namespace PublicArt.Util.Extensions
{
    public static class StringExtensions
    {
        public static string ShortenIfTooLong(this string value, int maxLength)
        {
            const string suffix = "...";

            if (string.IsNullOrEmpty(value)) return value;

            return value.Length <= maxLength ? value : value.Substring(0, maxLength - suffix.Length).TrimEnd() + suffix;
        }

        /// <summary>
        /// Attempts to shorten a URL string to a maximum length by removing substrings
        /// </summary>
        /// <param name="url">The URL string to shorten</param>
        /// <param name="max">The maximum length</param>
        /// <returns>Shortened URL string</returns>
        public static string TrimUrl(this string url, int max)
        {
            if (url == null) throw new ArgumentNullException(nameof(url));
            if (max <= 0) throw new ArgumentOutOfRangeException(nameof(url), max, "Max must be greater than zero");

            if (url.Length <= max) return url;

            // Step 1: Remove http://
            url = url.Replace("http://", "");
            if (url.Length <= max) return url;

            // Step 2: Remove query string
            var queryIndex = url.IndexOf("?", StringComparison.Ordinal);
            if (queryIndex > 0) url = url.Substring(0, queryIndex);
            if (url.Length <= max) return url;

            // Step 2: Remove anchor
            var anchorIndex = url.IndexOf("#", StringComparison.Ordinal);
            if (anchorIndex > 0) url = url.Substring(0, anchorIndex);
            if (url.Length <= max) return url;

            // Step 4: Condense path
            var slashIndex1 = url.IndexOf("/", StringComparison.Ordinal);
            var slashIndex2 = url.LastIndexOf("/", StringComparison.Ordinal);
            if (slashIndex1 < slashIndex2)
                url = url.Replace(url.Substring(slashIndex1, slashIndex2 - slashIndex1), "/...");
            if (url.Length <= max) return url;

            // Step 5: Remove path completely
            if (slashIndex1 > 0) url = url.Substring(0, slashIndex1);
            if (url.Length <= max) return url;

            // Step 6: Condense domain
            var dotIndex1 = url.IndexOf(".", StringComparison.Ordinal) + 1;
            var dotIndex2 = url.IndexOf(".", dotIndex1, StringComparison.Ordinal) - 1;
            var charsToRemove = url.Length - max + 3;
            if (dotIndex2 - dotIndex1 > 4 && dotIndex2 - dotIndex1 >= charsToRemove)
            {
                var mid = ((dotIndex2 - dotIndex1) / 2) + dotIndex1;
                url = url.Substring(0, mid - (charsToRemove / 2)) + "..." + url.Substring(mid - (charsToRemove / 2) + charsToRemove);
            }
            if (url.Length <= max) return url;

            throw new FormatException($"Unable to shorten URL to maximum limit ({max})");
        }
    }
}