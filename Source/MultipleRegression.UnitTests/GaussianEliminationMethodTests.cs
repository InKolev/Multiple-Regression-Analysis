namespace MultipleRegression.UnitTests
{
    using Core;
    using NUnit.Framework;

    [TestFixture]
    public class GaussianEliminationMethodTests
    {
        [Test]
        public void Solve_ValidSystemOfEquations_ReturnsExpectedResult_1()
        {
            var method = new GaussianEliminationMethod();
            var system = new decimal[,]
            {
                { 1, 2, 1, 1 },
                { 1, 3, 2, 2 },
                { 2, 1, 0, 1 }
            };

            var actualResult = method.Solve(system);
            var expectedResult = new decimal[] { 1, -1, 2 };

            AssertArraysAreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Solve_ValidSystemOfEquations_ReturnsExpectedResult_2()
        {
            var method = new GaussianEliminationMethod();
            var system = new decimal[,]
            {
                { 6, 4863, 8761, 654, 714 },
                { 4863, 4521899, 8519938, 620707, 667832 },
                { 8761, 8519938, 21022091, 905925, 1265493 },
                { 654, 620707, 905925, 137902, 100583 }
            };

            var actualResult = method.Solve(system);
            var expectedResult = new decimal[] { 6.667m, 0.078m, 0.015m, 0.246m };
            var delta = 0.001d;

            this.AssertArraysAreEqual(expectedResult, actualResult, delta);
        }

        private void AssertArraysAreEqual(decimal[] expected, decimal[] actual, double delta = 0d)
        {
            Assert.AreEqual(expected.Length, actual.Length);

            for (int i = 0; i < expected.Length; i++)
            {
                var expectedValue = (double)expected[i];
                var actualValue = (double)actual[i];

                Assert.AreEqual(expectedValue, actualValue, delta);
            }
        }
    }
}
