using Erpi.UnitTest.Demo.Refactored.Verifier;
using NUnit.Framework;

namespace Erpi.UnitTest.Demo.Refactored.Tests.VerifierTests
{
    [TestFixture]
    public class WhateverTipVerifierTest
    {
        private WhateverTipVerifier _verifier;

        [SetUp]
        public void Init()
        {
            _verifier = new WhateverTipVerifier();
        }

        [TestCase(-100000.56)]
        [TestCase(-5.26)]
        [TestCase(-0.01)]
        [TestCase(0.00)]
        [TestCase(0.01)]
        [TestCase(16.79)]
        [TestCase(100000000.99)]
        public void ReturnTrueForAnyInputNumber(decimal amount)
        {
            var result = _verifier.Verify(amount);
            Assert.IsTrue(result);
        }
    }
}
