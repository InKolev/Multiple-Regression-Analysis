using System;
using MultipleRegression.Core.Interfaces;
using MultipleRegression.Core.SolutionMethods;
using NUnit.Framework;

namespace MultipleRegression.UnitTests
{
    [TestFixture]
    public class GaussianEliminationMethodTests
    {
        private const double Delta = 0.1;
        private ISolutionMethod solutionMethod;

        [SetUp]
        public void TestSetup()
        {
            this.solutionMethod = new GaussianEliminationSolutionMethod();
        }

        [Test]
        public void Solve_ValidSystemOfEquations_ReturnsExpectedResult_FirstCase()
        {
            var systemToSolve = new double[,]
            {
                { 1, 2, 1, 1 },
                { 1, 3, 2, 2 },
                { 2, 1, 0, 1 }
            };
            var expectedResult = new double[] { 1, -1, 2 };

            var actualResult = this.solutionMethod.Solve(systemToSolve);

            AssertArraysAreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Solve_ValidSystemOfEquations_ReturnsExpectedResult_SecondCase()
        {
            var systemToSolve = new double[,]
            {
                { 6, 4863, 8761, 654, 714 },
                { 4863, 4521899, 8519938, 620707, 667832 },
                { 8761, 8519938, 21022091, 905925, 1265493 },
                { 654, 620707, 905925, 137902, 100583 }
            };
            var expectedResult = new double[] { 6.7013, 0.0784, 0.0150, 0.2461 };

            var actualResult = this.solutionMethod.Solve(systemToSolve);

            this.AssertArraysAreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Solve_ValidSystemOfEquations_ReturnsExpectedResult_ThirdCase()
        {
            var systemToSolve = new double[,]
            {
                { 6, 4863, 8761, 654, 714 },
                { 4863, 4521899, 8519938, 620707, 667832 },
                { 8761, 0, 21022091, 905925, 1265493 },
                { 0, 620707, 905925, 137902, 100583 }
            };
            var expectedResult = new double[] { 20, 0.012576, 0.043528, 0.38682 };

            var actualResult = this.solutionMethod.Solve(systemToSolve);

            this.AssertArraysAreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Solve_NullSystemOfEquations_ThrowsArgumentNullException()
        {
            double[,] systemOfEquations = null;

            var exc = Assert.Throws<ArgumentNullException>(() => this.solutionMethod.Solve(systemOfEquations));

            var expectedExceptionMessage = $"Argument '{nameof(systemOfEquations)}'";
            var actualExceptionMessage = exc.Message;
            StringAssert.Contains(expectedExceptionMessage, actualExceptionMessage);
        }

        private void AssertArraysAreEqual(double[] expected, double[] actual)
        {
            Assert.AreEqual(expected.Length, actual.Length);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i], Delta);
            }
        }
    }
}
