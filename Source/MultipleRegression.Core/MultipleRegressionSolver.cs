using System.Collections.Generic;
using MultipleRegression.Core.Factories.Interfaces;
using MultipleRegression.Core.Formatters.Interfaces;
using MultipleRegression.Core.SolutionMethods;
using System;

namespace MultipleRegression.Core
{
    public class MultipleRegressionSolver
    {
        private IDataTableFormatter tableFormatter;
        private ISolutionMethodFactory solutionFactory;

        public MultipleRegressionSolver(ISolutionMethodFactory solutionMethodFactory, IDataTableFormatter formatter)
        {
            this.solutionFactory = solutionMethodFactory;
            this.tableFormatter = formatter;
        }

        public double[] Solve(SolutionMethodType solutionMethod, Dictionary<string, List<double>> historicalData)
        {
            this.ValidateSolveArguments(historicalData);

            var system = this.tableFormatter.Format(historicalData);
            var method = this.solutionFactory.GetSolutionMethod(solutionMethod);
            var coefficients = method.Solve(system);

            return coefficients;
        }

        public double Classify(double[] inputRow, double[] coefficients)
        {
            this.ValidateClassifyArguments(inputRow, coefficients);

            double result = coefficients[0];
            for (int i = 0; i < inputRow.Length; i++)
            {
                result += coefficients[i + 1] * inputRow[i];
            }

            return result;
        }

        private void ValidateSolveArguments(Dictionary<string, List<double>> historicalData)
        {
            if (historicalData == null)
            {
                throw new ArgumentNullException($"Cannot solve for null value of parameter: \"{nameof(historicalData)}\"");
            }
        }

        private void ValidateClassifyArguments(double[] inputRow, double[] coefficients)
        {
            if (inputRow == null)
            {
                throw new ArgumentNullException($"Cannot classify for null value of parameter: \"{nameof(inputRow)}\"");
            }

            if (coefficients == null)
            {
                throw new ArgumentNullException($"Cannot classify for null value of parameter: \"{nameof(coefficients)}\"");
            }

            if (inputRow.Length != coefficients.Length - 1)
            {
                throw new ArgumentOutOfRangeException($"{nameof(inputRow)} length should be with 1 lesser than the length of {nameof(coefficients)}");
            }
        }
    }
}
