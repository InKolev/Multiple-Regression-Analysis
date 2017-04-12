using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleRegression.Core
{
    public class MultipleRegressionSolver
    {
        public void Solve(SolutionMethod solutionMethod, Dictionary<string, List<decimal>> historicalData)
        {
            var inputFormatter = new DataTableToSystemOfEquationsFormatter();
            var formatedInput = inputFormatter.Format(historicalData);
            // choose strategy
            // format input for strategy
            // solve using strategy
            // get criterions weight from the strategy
            // return the criterionsWeight

            var criterionsWeight = new Dictionary<string, decimal>(); // criterion(string), weight(decimal)
        }
    }
}
