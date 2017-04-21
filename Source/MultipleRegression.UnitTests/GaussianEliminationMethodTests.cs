namespace MultipleRegression.UnitTests
{
    using Core;
    using NUnit.Framework;

    [TestFixture]
    public class GaussianEliminationMethodTests
    {
        [Test]
        public void Solve_ValidSystemOfEquations_ReturnsExpectedResult()
        {
            var method = new GaussianEliminationMethod();
            var system = new decimal[,]
            {
                { 1, 2, 1, 1 },
                { 1, 3, 2, 2 },
                { 2, 1, 0, 1 }
            };

            var result = method.Solve(system);
            var expectedResult = new decimal[] { 1, -1, 2 };

            Assert.AreEqual(expectedResult, result);
        }
    }
}
