namespace MostCommonValue
{
    using NUnit.Framework;

    [TestFixture]
    public class AnalyserTests
    {
        [Test]
        public void IntTest()
        {
            var testArray = new[] { 3, 4, 5, 3, 3, 1, 3, 7, 8, 3, 2 };

            var mostFrequent = Analyser.GetMostCommon<int>(testArray);

            Assert.AreEqual(mostFrequent.Item1, 3);
        }
    }
}
