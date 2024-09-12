namespace Dinners2.Extensions
{
    public class Extensions
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
    }
}