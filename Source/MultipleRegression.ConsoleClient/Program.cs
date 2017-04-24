using System;
using System.Collections.Generic;
using System.Linq;
using MultipleRegression.Core;
using MultipleRegression.Core.Factories;
using MultipleRegression.Core.Formatters;
using MultipleRegression.Core.SolutionMethods;

namespace MultipleRegression.ConsoleClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var historicalData = GetHistoricalData();

            var regressionSolver =
                new MultipleRegressionSolver(
                    new SolutionMethodFactory(),
                    new DataTableFormatter());

            var coefficients =
                regressionSolver.Solve(
                    SolutionMethodType.GaussianElimination,
                    historicalData);

            Console.WriteLine(
                String.Join(
                    separator: ", ",
                    values: coefficients.Select(x => Math.Round(x, 5))));

            var inputRow = new double[] { 983, 2896, 120 };
            var Zk = regressionSolver.Classify(inputRow, coefficients);
            Console.WriteLine(Zk);
        }

        public static Dictionary<string, List<double>> GetHistoricalData()
        {
            return new Dictionary<string, List<double>>()
            {
                {"w", new List<double> { 1142, 863, 1065, 554, 983, 256 } },
                {"x", new List<double> { 1060, 995, 3205, 120, 2896, 485 } },
                {"y", new List<double> { 325, 98d, 23d, 0d, 120, 88d } },
                {"z", new List<double> { 201, 98d, 162, 54d, 138, 61d } }
            };
        }
    }
}
