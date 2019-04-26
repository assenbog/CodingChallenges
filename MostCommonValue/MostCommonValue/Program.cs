using System;

namespace MostCommonValue
{
    class Program
    {
        static void Main(string[] args)
        {
            var testIntArray = new[] { 3, 4, 5, 3, 3, 1, 3, 7, 8, 3, 2 };

            var mostFrequentInt = Analyser.GetMostCommon<int>(testIntArray);

            var testStringArray = new[] { "Assen", "Valia", "Iana", "Tsveta", "Alex", "Assen", "Valia", "Assen" };

            var mostFrequentString = Analyser.GetMostCommon<string>(testStringArray);
        }
    }
}
