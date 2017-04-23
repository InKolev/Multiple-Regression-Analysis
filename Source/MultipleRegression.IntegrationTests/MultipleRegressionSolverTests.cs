using System.Collections.Generic;
using MultipleRegression.Core;
using MultipleRegression.Core.Factories;
using MultipleRegression.Core.Formatters;
using MultipleRegression.Core.SolutionMethods;
using NUnit.Framework;

namespace MultipleRegression.IntegrationTests
{
    [TestFixture]
    public class MultipleRegressionSolverTests
    {
        private MultipleRegressionSolver solver;
        private const double Delta = 0.1;

        [SetUp]
        public void TestSetup()
        {
            this.solver = 
                new MultipleRegressionSolver(
                    new SolutionMethodFactory(), 
                    new DataTableFormatter());
        }

        [Test]
        public void Solve_ValidDataTable_ReturnsExpectedResult_FirstCase()
        {
            var dataTable = this.GetDataTableForFirstTestCase();
            var expectedResult = this.GetExpectedResultForFirstTestCase();

            var actualResult = this.solver.Solve(SolutionMethodType.GaussianElimination, dataTable);

            AssertArraysAreEqual(expectedResult, actualResult, Delta);
        }

        [Test]
        public void Solve_ValidDataTable_ReturnsExpectedResult_SecondCase()
        {
            var dataTable = this.GetDataTableForSecondTestCase();
            var expectedResult = this.GetExpectedResultForSecondTestCase();

            var actualResult = this.solver.Solve(SolutionMethodType.GaussianElimination, dataTable);

            AssertArraysAreEqual(expectedResult, actualResult, Delta);
        }

        private Dictionary<string, List<double>> GetDataTableForFirstTestCase()
        {
            return new Dictionary<string, List<double>>()
            {
                {"w", new List<double> { 345, 168, 94, 187, 621, 255 } },
                {"x", new List<double> { 65, 18, 0, 185, 87, 0 } },
                {"y", new List<double> { 23, 18, 0, 98, 10, 0 } },
                {"z", new List<double> { 31.4, 14.6, 6.4, 28.3, 42.1, 15.3 } }
            };
        }

        private Dictionary<string, List<double>> GetDataTableForSecondTestCase()
        {
            return new Dictionary<string, List<double>>()
            {
                {"w", new List<double> { 1142, 863, 1065, 554, 983, 256 } },
                {"x", new List<double> { 1060, 995, 3205, 120, 2896, 485 } },
                {"y", new List<double> { 325, 98d, 23d, 0d, 120, 88d } },
                {"z", new List<double> { 201, 98d, 162, 54d, 138, 61d } }
            };
        }

        private double[] GetExpectedResultForFirstTestCase()
        {
            return new double[] { 0.56645, 0.06533, 0.008719, 0.15105 };
        }

        private double[] GetExpectedResultForSecondTestCase()
        {
            return new double[] { 6.7013, 0.0784, 0.0150, 0.2461 };
        }

        private void AssertArraysAreEqual(double[] expected, double[] actual, double delta)
        {
            Assert.AreEqual(expected.Length, actual.Length);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i], delta);
            }
        }
    }
}
