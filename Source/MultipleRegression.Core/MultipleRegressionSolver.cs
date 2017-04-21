using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public decimal[] Solve(SolutionMethod solutionMethod, Dictionary<string, List<decimal>> historicalData)
        {
            var system = this.tableFormatter.Format(historicalData);
            var method = this.solutionFactory.GetSolutionMethod(solutionMethod);
            var coefficients = method.Solve(system);

            return coefficients;
        }
    }
}
