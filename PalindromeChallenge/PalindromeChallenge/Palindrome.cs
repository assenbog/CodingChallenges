namespace PalindromeChallenge
{
    using System.Collections.Generic;
    using System.Linq;

    public class Palindrome
    {
        /// <summary>
        /// Break down the provided string into a Dictionary containing palindromes as keys
        /// and their corresponding index in the string as a value
        /// </summary>
        /// <param name="value">The string to looks for palindromes in</param>
        /// <param name="topN">Top N results in terms of palindrome length specifier</param>
        /// <returns>Dictionary of palindromes and their index positions</returns>
        public Dictionary<string, int> GetTopNPalindromes(string value, int topN)
        {
            var palindromes = new Dictionary<string,int>();

            for (var i = 0; i < value.Length; i++)
            {
                var currentChar = value[i];
                var matchingCharPositions = new List<int>();
                var palindromeFound = false;
                int palindromeRightIndex = i;

                for (var j = i + 3; j < value.Length; j++)
                {
                    if (value[j] == currentChar)
                    {
                        matchingCharPositions.Add(j);
                    }

                    if (matchingCharPositions.Any())
                    {
                        foreach (var matchingCharPosition in matchingCharPositions.OrderByDescending(p => p))
                        {
                            var stringToCheck = value.Substring(i, matchingCharPosition - i + 1);

                            if (stringToCheck.IsPalindrome() && !palindromes.ContainsKey(stringToCheck))
                            {
                                palindromeFound = true;
                                palindromeRightIndex = matchingCharPosition;
                                palindromes.Add(stringToCheck, i);
                            }
                        }
                    }
                }

                if (palindromeFound)
                {
                    // Adjust to continued search start position accordingly
                    i = palindromeRightIndex;
                }
            }

            return palindromes.OrderByDescending(p => p.Key.Length).Take(topN).ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
