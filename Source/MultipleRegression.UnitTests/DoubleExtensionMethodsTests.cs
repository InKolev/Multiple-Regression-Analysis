using MultipleRegression.Core.Extensions;
using NUnit.Framework;

namespace MultipleRegression.UnitTests
{
    [TestFixture]
    public class DoubleExtensionMethodsTests
    {
        [Test]
        public void IsPositive_PositiveNumber_ReturnsTrue()
        {
            var number = 10.00d;

            Assert.IsTrue(number.IsPositive());
        }

        [Test]
        public void IsPositive_ZeroNumber_ReturnsFalse()
        {
            var number = 0.00d;

            Assert.IsFalse(number.IsPositive());
        }

        [Test]
        public void IsPositive_NegativeNumber_ReturnsFalse()
        {
            var number = -10.00d;

            Assert.IsFalse(number.IsPositive());
        }

        [Test]
        public void IsNegative_PositiveNumber_ReturnsFalse()
        {
            var number = 10.00d;

            Assert.IsFalse(number.IsNegative());
        }

        [Test]
        public void IsNegative_ZeroNumber_ReturnsFalse()
        {
            var number = 0.00d;

            Assert.IsFalse(number.IsNegative());
        }

        [Test]
        public void IsNegative_NegativeNumber_ReturnsTrue()
        {
            var number = -10.00d;

            Assert.IsTrue(number.IsNegative());
        }

        [Test]
        public void IsZero_ZeroNumber_ReturnsTrue()
        {
            var number = 0.00d;

            Assert.IsTrue(number.IsZero());
        }

        [Test]
        public void IsZero_NegativeNumber_ReturnsFalse()
        {
            var number = -10.00d;

            Assert.IsFalse(number.IsZero());
        }

        [Test]
        public void IsZero_PositiveNumber_ReturnsFalse()
        {
            var number = 10.00d;

            Assert.IsFalse(number.IsZero());
        }

        [Test]
        public void IsGreaterThan_LesserNumber_ReturnsTrue()
        {
            var number = 100d;
            var lesserNumber = 10d;

            Assert.IsTrue(number.IsGreaterThan(lesserNumber));
        }

        [Test]
        public void IsGreaterThan_GreaterNumber_ReturnsFalse()
        {
            var number = 100d;
            var greaterNumber = 1000d;

            Assert.IsFalse(number.IsGreaterThan(greaterNumber));
        }

        [Test]
        public void IsLessThan_LowerNumber_ReturnsFalse()
        {
            var number = 100d;
            var lesserNumber = 10d;

            Assert.IsFalse(number.IsLessThan(lesserNumber));
        }

        [Test]
        public void IsLessThan_GreaterNumber_ReturnsFalse()
        {
            var number = 10d;
            var greaterNumber = 100d;

            Assert.IsTrue(number.IsLessThan(greaterNumber));
        }
    }
}
