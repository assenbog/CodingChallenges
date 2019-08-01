namespace SimCorpChallenge
{
    using System.Collections.Generic;

    public interface IWordCounter
    {
        void LoadWords(string fileName);

        IEnumerable<string> GetWordCount();
    }
}
