using System.Collections.Generic;
using MultipleRegression.Core.Factories.Interfaces;
using MultipleRegression.Core.Formatters.Interfaces;
using MultipleRegression.Core.SolutionMethods;

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
            var system = this.tableFormatter.Format(historicalData);
            var method = this.solutionFactory.GetSolutionMethod(solutionMethod);
            var coefficients = method.Solve(system);

            return coefficients;
        }

        public double Classify(double[] input, double[] coefficientsWeight)
        {
            double result = coefficientsWeight[0];

            for (int i = 0; i < input.Length; i++)
            {
                result += coefficientsWeight[i + 1] * input[i];
            }

            return result;
        }
    }
}
