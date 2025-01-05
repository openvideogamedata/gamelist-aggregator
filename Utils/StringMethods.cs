using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace community.Utils
{
    public static class StringMethods
    {
        public static string ToUrlSlug(this string value){
            value = value.ToLowerInvariant();
            var bytes = Encoding.GetEncoding("UTF-8").GetBytes(value);
            value = Encoding.ASCII.GetString(bytes);
            value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled);
            value = Regex.Replace(value, @"[^a-z0-9\s-_]", "",RegexOptions.Compiled);
            value = value.Trim('-', '_');
            value = Regex.Replace(value, @"([-_]){2,}", "$1", RegexOptions.Compiled);
            return value;
        }

        public static string ReplaceSpecialCharacters(this string text)
        {
            try
            {
                return new string(text
                    .Normalize(NormalizationForm.FormD)
                    .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                    .ToArray());
            }
            catch(Exception)
            {
                return text;
            }
        }

        public static string FirstCharToUpper(this string input) =>
            input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
            };
    }
}