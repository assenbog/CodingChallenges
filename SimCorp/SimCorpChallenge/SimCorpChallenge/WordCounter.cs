namespace SimCorpChallenge
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class WordCounter : IWordCounter
    {
        List<string> _words;

        public WordCounter()
        {
            _words = new List<string>();
        }

        public IEnumerable<string> GetWordCount()
        {
            return from word in _words
                   group word by word into sameWords
                   select $"{sameWords.Count()}:{sameWords.Key}";
        }

        public void LoadWords(string fileName)
        {
            try
            {
                using (var sr = new StreamReader(fileName))
                {
                    while (!sr.EndOfStream)
                    {
                        var inputLine = sr.ReadLine();
                        _words.AddRange(inputLine.Split(' '));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing file \"{fileName}\": {ex.ToString()}");
            }
        }
    }
}
