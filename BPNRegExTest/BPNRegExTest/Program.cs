namespace BPNRegExTest
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            const string textExpr = "1y6m";

            int? years;
            int? months;
            int? weeks;
            int? days;

            //var regEx = new Regex(@"^(\d*)[yY]?(\d*)[mM]?(\d*)[wW]?(\d*)[dD]$");

            var yearRegEx = new Regex(@"(\d*)(?=[yY]{1})");
            var monthRegEx = new Regex(@"(\d*)(?=[mM]{1})");
            var weekRegEx = new Regex(@"(\d*)(?=[wW]{1})");
            var dayRegEx = new Regex(@"(\d*)(?=[dD]{1})");

            var yearMatch = yearRegEx.Match(textExpr);

            if (yearMatch.Success)
            {
                years = int.Parse(yearMatch.Groups[1].Value);
            }

            var monthsMatch = monthRegEx.Match(textExpr);

            if (monthsMatch.Success)
            {
                months = int.Parse(monthsMatch.Groups[1].Value);
            }

            var weeksMatch = weekRegEx.Match(textExpr);

            if (weeksMatch.Success)
            {
                weeks = int.Parse(weeksMatch.Groups[1].Value);
            }

            var daysMatch = dayRegEx.Match(textExpr);

            if (daysMatch.Success)
            {
                days = int.Parse(daysMatch.Groups[1].Value);
            }

            Console.ReadKey();
        }
    }
}
