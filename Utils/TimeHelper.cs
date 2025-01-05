using Microsoft.Extensions.Localization;

namespace community.Utils
{
    public static class TimeHelper {
        /// <summary>
        /// Convert a <see cref="TimeSpan"/> to a natural language representation.
        /// </summary>
        /// <example>
        /// <code>
        /// TimeSpan.FromSeconds(10).ToNaturalLanguage();
        /// // 10 seconds
        /// </code>
        /// </example>
        public static string ToNaturalLanguage(this TimeSpan @this)
        {
            const int daysInWeek = 7;
            const int daysInMonth = 30;
            const int daysInYear = 365;
            const long threshold = 100 * TimeSpan.TicksPerMillisecond;
            @this = @this.TotalSeconds < 0
                ? TimeSpan.FromSeconds(@this.TotalSeconds * -1)
                : @this;
            return (@this.Ticks + threshold) switch
            {
                < 2 * TimeSpan.TicksPerSecond => "a second",
                < 1 * TimeSpan.TicksPerMinute => @this.Seconds + " seconds",
                < 2 * TimeSpan.TicksPerMinute => "a minute",
                < 1 * TimeSpan.TicksPerHour => @this.Minutes + " minutes",
                < 2 * TimeSpan.TicksPerHour => "an hour",
                < 1 * TimeSpan.TicksPerDay => @this.Hours + " hours",
                < 2 * TimeSpan.TicksPerDay => "a day",
                < 1 * daysInWeek * TimeSpan.TicksPerDay => @this.Days + " days",
                < 2 * daysInWeek * TimeSpan.TicksPerDay => "a week",
                < 1 * daysInMonth * TimeSpan.TicksPerDay => (@this.Days / daysInWeek).ToString("F0") + " weeks",
                < 2 * daysInMonth * TimeSpan.TicksPerDay => "a month",
                < 1 * daysInYear * TimeSpan.TicksPerDay => (@this.Days / daysInMonth).ToString("F0") + " months",
                < 2 * daysInYear * TimeSpan.TicksPerDay => "a year",
                _ => (@this.Days / daysInYear).ToString("F0") + " years"
            };
        }

        public static string ToNaturalLanguage<T>(this TimeSpan @this, IStringLocalizer<T> loc)
        {
            const int daysInWeek = 7;
            const int daysInMonth = 30;
            const int daysInYear = 365;
            const long threshold = 100 * TimeSpan.TicksPerMillisecond;
            @this = @this.TotalSeconds < 0
                ? TimeSpan.FromSeconds(@this.TotalSeconds * -1)
                : @this;
            return (@this.Ticks + threshold) switch
            {
                < 2 * TimeSpan.TicksPerSecond => $"{loc["a"]} {loc["second"]}",
                < 1 * TimeSpan.TicksPerMinute => @this.Seconds + $" {loc["second"]}s",
                < 2 * TimeSpan.TicksPerMinute => $"{loc["a"]} {loc["minute"]}",
                < 1 * TimeSpan.TicksPerHour => @this.Minutes + $" {loc["minute"]}s",
                < 2 * TimeSpan.TicksPerHour => $"{loc["an_f"]} {loc["hour"]}",
                < 1 * TimeSpan.TicksPerDay => @this.Hours + $" {loc["hour"]}s",
                < 2 * TimeSpan.TicksPerDay => $"{loc["a"]} {loc["day"]}",
                < 1 * daysInWeek * TimeSpan.TicksPerDay => @this.Days + $" {loc["day"]}s",
                < 2 * daysInWeek * TimeSpan.TicksPerDay => $"{loc["a_f"]} {loc["week"]}",
                < 1 * daysInMonth * TimeSpan.TicksPerDay => (@this.Days / daysInWeek).ToString("F0") + $" {loc["week"]}s",
                < 2 * daysInMonth * TimeSpan.TicksPerDay => $"{loc["a"]} {loc["month"]}",
                < 1 * daysInYear * TimeSpan.TicksPerDay => (@this.Days / daysInMonth).ToString("F0") + $" {loc["months"]}",
                < 2 * daysInYear * TimeSpan.TicksPerDay => $"{loc["a"]} {loc["year"]}",
                _ => (@this.Days / daysInYear).ToString("F0") + $" {loc["year"]}s"
            };
        }

        /// <summary>
        /// Convert a <see cref="DateTime"/> to a natural language representation.
        /// </summary>
        /// <example>
        /// <code>
        /// (DateTime.Now - TimeSpan.FromSeconds(10)).ToNaturalLanguage()
        /// // 10 seconds ago
        /// </code>
        /// </example>
        public static string ToNaturalLanguage(this DateTime @this, bool appendText = true)
        {
            TimeSpan timeSpan = @this - DateTime.Now;
            return timeSpan.TotalSeconds switch
            {
                >= 1 => timeSpan.ToNaturalLanguage() + $"{(appendText ? " until" : "")}",
                <= -1 => timeSpan.ToNaturalLanguage() + $"{(appendText ? " ago" : "")}",
                _ => "now",
            };
        }

        public static string ToNaturalLanguage<T>(this DateTime @this, bool appendText = true, IStringLocalizer<T> loc = null)
        {
            if (loc == null)
                return ToNaturalLanguage(@this, appendText);

            try
            {
                TimeSpan timeSpan = @this - DateTime.Now;
                return timeSpan.TotalSeconds switch
                {
                    >= 1 => timeSpan.ToNaturalLanguage<T>(loc) + $"{(appendText ? $" {loc["until"]}" : "")}",
                    <= -1 => timeSpan.ToNaturalLanguage<T>(loc) + $"{(appendText ? $" {loc["ago"]}" : "")}",
                    _ => $"{loc["now"]}",
                };
            }
            catch
            {
                return "some time ago";
            }
        }

        public static string ToLastUpdatedFormat(this DateTime? @this) {
            return @this != null ? $"({@this?.ToString("MM/yyyy")})" : string.Empty;
        }
    }
}