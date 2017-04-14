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
            decimal a = 14.00m;
            decimal b = 27.00m;

            // Compute multiplier
            

            decimal result = b + a * multiplier;

            Console.WriteLine(result);

            //var multipleRegressionSolver = new MultipleRegressionSolver();
            //var historicalData = new Dictionary<string, List<decimal>>()
            //{
            //    {"w", new List<decimal> { 1142m, 863m, 1065m, 554m, 983m, 256m } },
            //    {"x", new List<decimal> { 1060m, 995m, 3205m, 120m, 2896m, 485m } },
            //    {"y", new List<decimal> { 325m, 98m, 23m, 0m, 120m, 88m } },
            //    {"z", new List<decimal> { 201m, 98m, 162m, 54m, 138m, 61m } }
            //};

            //multipleRegressionSolver.Solve(SolutionMethod.GaussianEliminationMethod, historicalData);
        }
    }
}
