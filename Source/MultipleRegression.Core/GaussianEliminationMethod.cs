using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultipleRegression.Core.ExtensionMethods;

namespace MultipleRegression.Core
{
    public class GaussianEliminationMethod : ISolutionMethod
    {
        public decimal[] Solve(decimal[,] systemOfEquations)
        {
            var rowsCount = systemOfEquations.GetLength(0);
            var colsCount = systemOfEquations.GetLength(1);

            for (int currentRow = 0; currentRow < rowsCount; currentRow++)
            {
                var rowsToMutate = Enumerable.Range(0, rowsCount).ToList();
                rowsToMutate.Remove(currentRow);
                rowsToMutate.Sort();
                rowsToMutate.Reverse();

                var columnToMutate = currentRow;
                var a = systemOfEquations[currentRow, columnToMutate];

                foreach (var rowToMutate in rowsToMutate)
                {
                    var b = systemOfEquations[rowToMutate, columnToMutate];

                    if (!this.ShouldContinueProcessing(b))
                    {
                        break;
                    }

                    var multiplier = this.ComputeMultiplier(a, b);

                    for (int col = 0; col < colsCount; col++)
                    {
                        var x = systemOfEquations[currentRow, col];
                        var y = systemOfEquations[rowToMutate, col];
                        var z = x * multiplier;

                        systemOfEquations[rowToMutate, col] = Math.Round(y + z);
                    }
                }
            }

            var coefficients = new decimal[rowsCount];
            for (int row = 0; row < rowsCount; row++)
            {
                coefficients[row] = systemOfEquations[row, colsCount - 1] / systemOfEquations[row, row];
            }

            return coefficients;
        }

        private bool ShouldContinueProcessing(decimal b)
        {
            if (b.IsZero())
            {
                return false;
            }

            return true;
        }

        private decimal ComputeMultiplier(decimal a, decimal b)
        {
            decimal multiplier = 0m;
            decimal absoluteA = Math.Abs(a);
            decimal absoluteB = Math.Abs(b);

            if (absoluteA.IsGreaterThan(absoluteB))
            {
                multiplier = 1m / (absoluteA / absoluteB);
            }
            else
            {
                multiplier = absoluteB / absoluteA;
            }

            if (this.BothNumbersArePositive(a, b) || this.BothNumbersAreNegative(a, b))
            {
                multiplier *= -1m;
            }

            return multiplier;
        }

        private bool BothNumbersArePositive(decimal a, decimal b)
        {
            return a.IsPositive() && b.IsPositive();
        }

        private bool BothNumbersAreNegative(decimal a, decimal b)
        {
            return a.IsNegative() && b.IsNegative();
        }
    }
}
