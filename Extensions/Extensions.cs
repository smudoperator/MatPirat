namespace Dinners2.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// .Contains - but case insensitive
        /// </summary>
        /// <param name="source"></param>
        /// <param name="toCheck"></param>
        /// <param name="comp"></param>
        /// <returns></returns>
        public static bool Contains2(string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }

        public static DayOfWeek Next(this DayOfWeek day)
        {
            switch(day)
            {
                case DayOfWeek.Monday: return DayOfWeek.Tuesday;
                case DayOfWeek.Tuesday: return DayOfWeek.Wednesday;
                case DayOfWeek.Wednesday: return DayOfWeek.Thursday;
                case DayOfWeek.Thursday: return DayOfWeek.Friday;
                case DayOfWeek.Friday: return DayOfWeek.Saturday;
                case DayOfWeek.Saturday: return DayOfWeek.Sunday;
                case DayOfWeek.Sunday: return DayOfWeek.Monday;
            }
            return day;
        }
    }
}