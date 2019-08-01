namespace SimCorpChallenge
{
    using System;

    class Program
    {
        static void Main()
        {
            var testData = @"..\..\Data\TestData.txt";

            var wordCounter = new WordCounter();

            wordCounter.LoadWords(testData);

            var wordCount = wordCounter.GetWordCount();

            foreach (var row in wordCount)
            {
                Console.WriteLine(row);
            }

            Console.Write("\nPress any key to exit ... ");

            Console.ReadKey();
        }
    }
}
