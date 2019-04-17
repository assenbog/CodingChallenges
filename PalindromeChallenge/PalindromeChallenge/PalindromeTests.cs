namespace PalindromeChallenge
{
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class PalindromeTests
    {
        [Test]
        public void PalindomeTestPositive1()
        {
            Assert.IsTrue("hijkllkjih".IsPalindrome());
        }

        [Test]
        public void PalindomeTestPositive2()
        {
            Assert.IsTrue("defggfed".IsPalindrome());
        }

        [Test]
        public void PalindomeTestPositive3()
        {
            Assert.IsTrue("abccba".IsPalindrome());
        }

        [Test]
        public void PalindomeTestNegative1()
        {
            Assert.IsFalse("abcbba".IsPalindrome());
        }

        [Test]
        public void PalindomeTestNegative2()
        {
            // Note: Odd number of chars
            Assert.IsFalse("abcba".IsPalindrome());
        }

        [Test]
        public void AllPalindomeTestResults()
        {
            var testString = "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop";

            var palindrome = new Palindrome();

            // Get the Top 3 palindromes by text length
            var palindromes = palindrome.GetTopNPalindromes(testString, 3);

            var palindromeKeys = palindromes.Keys.ToArray();
            var palindromeIndices = palindromes.Values.ToArray();

            Assert.AreEqual(palindromeKeys[0], "hijkllkjih");
            Assert.AreEqual(palindromeIndices[0], 23);

            Assert.AreEqual(palindromeKeys[1], "defggfed");
            Assert.AreEqual(palindromeIndices[1], 13);

            Assert.AreEqual(palindromeKeys[2], "abccba");
            Assert.AreEqual(palindromeIndices[2], 5);
        }
    }
}
