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

        [Test]
        public void StringTest()
        {
            var testArray = new[] { "Assen", "Valia", "Iana", "Tsveta", "Alex", "Assen", "Valia", "Assen" };

            var mostFrequent = Analyser.GetMostCommon<string>(testArray);

            Assert.AreEqual(mostFrequent.Item1, "Assen");
        }

        [Test]
        public void CharTest()
        {
            var testArray = new[] { 'A', 'V', 'I', 'T', 'A', 'V', 'A' };

            var mostFrequent = Analyser.GetMostCommon<char>(testArray);

            Assert.AreEqual(mostFrequent.Item1, 'A');
        }

        [Test]
        public void DoubleTest()
        {
            var testArray = new[] { 1.2D, 3.4D, 5D, 2D, 1.2D };

            var mostFrequent = Analyser.GetMostCommon<double>(testArray);

            Assert.AreEqual(mostFrequent.Item1, 1.2D);
        }
    }
}
