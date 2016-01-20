using NUnit.Framework;
using Restponder.Models.Strings;
using System;

namespace UtilityLibrary.Tests.Strings
{
    [TestFixture]
    public class RandomStringGeneratorTests
    {
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(64)]
        [TestCase(100)]
        public void RandomStringIsOfTheCorrectLength(int stringLength)
        {
            var generatedString = RandomStringGenerator.AlphaNumericString(stringLength);

            Assert.AreEqual(stringLength, generatedString.Length);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(int.MinValue)]
        [TestCase(101)]
        [TestCase(int.MaxValue)]
        public void RandomStringInputLengthLessThanZeroAndGreaterThanMaxValueThrowsException(int stringLength)
        {
             Assert.Throws<ArgumentOutOfRangeException>(() => RandomStringGenerator.AlphaNumericString(stringLength));
        }
    }
}