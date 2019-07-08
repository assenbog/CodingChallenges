namespace Ldc
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void RegExTest1()
        {
            var test = @"AAAc91%cWwWkLq$1ci3_848v3d__K";

            var expectedResult = @"Ac91%cWwWkLq£1ci38v3dK";

            var transform = new Transform();

            var result = transform.Cleanup(test);

            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void RegExTest2()
        {
            var test = @"AAAbcDDefGGG";

            var expectedResult = @"AbcDefG";

            var transform = new Transform();

            var privateObject = new PrivateObject(transform);

            var result = (string)privateObject.Invoke("RemoveDuplicates", test);

            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void RegExTest3()
        {
            var test = @"A$A$AG$";

            var expectedResult = @"A£A£AG£";

            var transform = new Transform();

            var privateObject = new PrivateObject(transform);

            var result = (string)privateObject.Invoke("ReplaceDollarWithPound", test);

            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void RegExTest4()
        {
            var test = @"___asd4456_45";

            var expectedResult = @"asd565";

            var transform = new Transform();

            var privateObject = new PrivateObject(transform);

            var result = (string)privateObject.Invoke("RemoveUnderscoresAnd4", test);

            Assert.AreEqual(result, expectedResult);
        }
    }
}
