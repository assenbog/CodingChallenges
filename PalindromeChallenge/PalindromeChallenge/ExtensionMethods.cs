namespace PalindromeChallenge
{
    using System.Linq;

    public static class ExtensionMethods
    {
        public static bool IsPalindrome(this string value)
        {
            var valueLength = value.Length;

            if (valueLength % 2 == 1)
            {
                // Only even length strings can be palindromes
                return false;
            }

            var leftPart = value.Substring(0, valueLength / 2);
            var rightPartReversed = new string(value.Substring(valueLength / 2).Reverse().ToArray());

            return leftPart == rightPartReversed;
        }
    }
}
