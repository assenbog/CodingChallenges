namespace BNPTest.Utilities
{
    using System.Text.RegularExpressions;
    using Model;

    public static class ExtensionMethods
    {
        /// <summary>
        /// Used to parse a string similar to "1y6m1w2d" to a Tenor object
        /// </summary>
        /// <param name="tenorString"></param>
        /// <returns></returns>
        public static Tenor ToTenor(this string tenorString)
        {
            int? years = default(int?);
            int? months = default(int?); 
            int? weeks = default(int?);
            int? days = default(int?);

            var yearRegEx = new Regex(@"(\d*)(?=[yY]{1})");
            var monthRegEx = new Regex(@"(\d*)(?=[mM]{1})");
            var weekRegEx = new Regex(@"(\d*)(?=[wW]{1})");
            var dayRegEx = new Regex(@"(\d*)(?=[dD]{1})");

            var yearMatch = yearRegEx.Match(tenorString);

            if (yearMatch.Success)
            {
                years = int.Parse(yearMatch.Groups[1].Value);
            }

            var monthsMatch = monthRegEx.Match(tenorString);

            if (monthsMatch.Success)
            {
                months = int.Parse(monthsMatch.Groups[1].Value);
            }

            var weeksMatch = weekRegEx.Match(tenorString);

            if (weeksMatch.Success)
            {
                weeks = int.Parse(weeksMatch.Groups[1].Value);
            }

            var daysMatch = dayRegEx.Match(tenorString);

            if (daysMatch.Success)
            {
                days = int.Parse(daysMatch.Groups[1].Value);
            }

            return new Tenor(years, months, weeks, days);
        }
    }
}
