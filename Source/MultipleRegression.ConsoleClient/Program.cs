using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultipleRegression.Core;
using MultipleRegression.Core.ExtensionMethods;

namespace MultipleRegression.ConsoleClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var solutionFactory = new SolutionMethodFactory();
            var tableFormatter = new DataTableToSystemOfEquationsFormatter();

            var multipleRegressionSolver = 
                new MultipleRegressionSolver(
                    solutionFactory, 
                    tableFormatter);

            var historicalData = GetHistoricalData();
            var coefficients = 
                multipleRegressionSolver.Solve(
                    SolutionMethod.GaussianEliminationMethod, 
                    historicalData);
        }

        public static Dictionary<string, List<decimal>> GetHistoricalData()
        {
            return new Dictionary<string, List<decimal>>()
            {
                {"w", new List<decimal> { 1142m, 863m, 1065m, 554m, 983m, 256m } },
                {"x", new List<decimal> { 1060m, 995m, 3205m, 120m, 2896m, 485m } },
                {"y", new List<decimal> { 325m, 98m, 23m, 0m, 120m, 88m } },
                {"z", new List<decimal> { 201m, 98m, 162m, 54m, 138m, 61m } }
            };
        }
    }
}
