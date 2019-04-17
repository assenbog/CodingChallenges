namespace PalindromeChallenge
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Command line format: PalindromeChallenge StringToCheck");
                return;
            }

            var palindrome = new Palindrome();

            // Get the Top 3 palindromes by text length
            var palindromes = palindrome.GetTopNPalindromes(args[0], 3);

            foreach (KeyValuePair<string,int> kvp in palindromes)
            {
                Console.WriteLine($"Text: {kvp.Key}, Index: {kvp.Value}, Length: {kvp.Key.Length}");
            }
        }
    }
}
