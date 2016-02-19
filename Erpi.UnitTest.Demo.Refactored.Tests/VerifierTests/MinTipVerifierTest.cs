using Erpi.UnitTest.Demo.Refactored.Verifier;
using NUnit.Framework;

namespace Erpi.UnitTest.Demo.Refactored.Tests.VerifierTests
{
    [TestFixture]
    public class MinTipVerifierTest
    {
        private MinTipVerifier _verifier;

        [SetUp]
        public void Init()
        {
            _verifier = new MinTipVerifier();
        }

        /// <summary>
        /// It is one way to write unit tests for a function.
        /// However, this way tends to hide test cases parameters inside execution codes.
        /// That means harder to understand and more difficult to maintain.
        /// 
        /// One common practice in using NUnit is to limit the "Assert" statement to one
        /// within a test function. But how?
        /// </summary>
        [Test]
        public void ReturnTrueWhenInputGreaterThanZero()
        {
            var result = _verifier.Verify((decimal)0.01);
            Assert.IsTrue(result);

            result = _verifier.Verify((decimal)1.29);
            Assert.IsTrue(result);

            result = _verifier.Verify((decimal)20.56);
            Assert.IsTrue(result);

            result = _verifier.Verify((decimal)10000000.56);
            Assert.IsTrue(result);
        }


        /// <summary>
        /// TestCase attribute is here to help. One "Assert" per test.
        /// 
        /// Using TestCase attribute, test case parameters are clearly seen outside of the 
        /// test execution path, making it easy to add a new case or to modify an existing 
        /// one. At the same time, we avoid the tidious work of casting double to decimal.
        /// </summary>
        /// <param name="amount"></param>
        [TestCase(0.01)]
        [TestCase(1.29)]
        [TestCase(20.56)]
        [TestCase(10000000.56)]
        public void ReturnTrueWhenInputGreaterThanZero(decimal amount)
        {
            var result = _verifier.Verify(amount);
            Assert.IsTrue(result);
        }

        [TestCase(0.00)]
        [TestCase(-0.01)]
        [TestCase(-5.48)]
        [TestCase(-56865342.95)]
        public void ResultFalseWhenInputEqualToOrSmallerThanZero(decimal amount)
        {
            var result = _verifier.Verify(amount);
            Assert.IsFalse(result);
        }
    }
}
