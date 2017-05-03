using System.Collections.Generic;
using MultipleRegression.Core;
using MultipleRegression.Core.Factories;
using MultipleRegression.Core.Formatters;
using MultipleRegression.Core.SolutionMethods;
using NUnit.Framework;
using System;

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
            var expectedResult = this.GetExpectedResultForSolveFirstTestCase();

            var actualResult = this.solver.Solve(SolutionMethodType.GaussianElimination, dataTable);

            AssertArraysAreEqual(expectedResult, actualResult, Delta);
        }

        [Test]
        public void Solve_ValidDataTable_ReturnsExpectedResult_SecondCase()
        {
            var dataTable = this.GetDataTableForSecondTestCase();
            var expectedResult = this.GetExpectedResultForSolveSecondTestCase();

            var actualResult = this.solver.Solve(SolutionMethodType.GaussianElimination, dataTable);

            AssertArraysAreEqual(expectedResult, actualResult, Delta);
        }


        [Test]
        public void Solve_NullDataTable_ThrowsArgumentNullException()
        {
            var dataTable = (Dictionary<string, List<double>>)null;

            Assert.Throws<ArgumentNullException>(() => this.solver.Solve(SolutionMethodType.GaussianElimination, dataTable));
        }

        [Test]
        public void Classify_ValidArguments_ReturnsExpectedResult()
        {
            var dataTable = GetDataTableForSecondTestCase();
            var coefficients = this.solver.Solve(SolutionMethodType.GaussianElimination, dataTable);
            var inputRow = new double[] { 983, 2896, 120 };
            var expected = 156.78;

            var actual = this.solver.Classify(inputRow, coefficients);

            Assert.AreEqual(expected, actual, delta: 0.01);
        }

        [Test]
        public void Classify_NullInputRow_ThrowsArgumentNullException()
        {
            var dataTable = GetDataTableForSecondTestCase();
            var coefficients = new double[] { 32, 12, 42, 14 };
            var inputRow = (double[])null;

            var exc = Assert.Throws<ArgumentNullException>(() => this.solver.Classify(inputRow, coefficients));

            var actualExceptionMessage = exc.Message;
            var expectedToContainExceptionMessage = nameof(inputRow);
            var expectedToNotContainExceptionMessage = nameof(coefficients);
            StringAssert.Contains(expectedToContainExceptionMessage, actualExceptionMessage);
            StringAssert.DoesNotContain(expectedToNotContainExceptionMessage, actualExceptionMessage);
        }

        [Test]
        public void Classify_NullICoefficients_ThrowsArgumentNullException()
        {
            var dataTable = GetDataTableForSecondTestCase();
            var coefficients = (double[])null;
            var inputRow = new double[] { 983, 2896, 120 };

            var exc = Assert.Throws<ArgumentNullException>(() => this.solver.Classify(inputRow, coefficients));

            var actualExceptionMessage = exc.Message;
            var expectedToContainExceptionMessage = nameof(coefficients);
            var expectedToNotContainExceptionMessage = nameof(inputRow);
            StringAssert.Contains(expectedToContainExceptionMessage, actualExceptionMessage);
            StringAssert.DoesNotContain(expectedToNotContainExceptionMessage, actualExceptionMessage);
        }

        [TestCase(new double[] { 1 }, new double[] { 1 })]
        [TestCase(new double[] { 1, 2 }, new double[] { 1, 2 })]
        [TestCase(new double[] { 1, 2, 3, 4 }, new double[] { 1, 2, 3, 4 })]
        [TestCase(new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4 })]
        [TestCase(new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new double[] { 1, 2, 3, 4 })]
        [TestCase(new double[] { 1, 2, 3, 4 }, new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        public void Classify_ArgumentsWithInvalidLength_ThrowsArgumentNullException_FirstCase(double[] inputRow, double[] coefficients)
        {
            var dataTable = GetDataTableForSecondTestCase();

            var exc = Assert.Throws<ArgumentOutOfRangeException>(() => this.solver.Classify(inputRow, coefficients));
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

        private double[] GetExpectedResultForSolveFirstTestCase()
        {
            return new double[] { 0.56645, 0.06533, 0.008719, 0.15105 };
        }

        private double[] GetExpectedResultForSolveSecondTestCase()
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
