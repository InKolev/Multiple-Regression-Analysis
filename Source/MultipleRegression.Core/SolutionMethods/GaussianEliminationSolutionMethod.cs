using System;
using System.Linq;
using MultipleRegression.Core.Extensions;
using MultipleRegression.Core.Interfaces;

namespace MultipleRegression.Core.SolutionMethods
{
    public class GaussianEliminationSolutionMethod : ISolutionMethod
    {
        public double[] Solve(double[,] systemOfEquations)
        {
            this.ValidateArguments(systemOfEquations);

            this.SolveSystem(systemOfEquations);

            var coefficients = this.ComputeCoefficients(systemOfEquations);

            return coefficients;
        }

        private void ValidateArguments(double[,] systemOfEquations)
        {
            if (systemOfEquations.IsNull())
            {
                var nullParameterName = nameof(systemOfEquations);
                var nullParameterType = systemOfEquations.GetType().Name;
                var exceptionMessage = $"Argument '{nullParameterName}' of type '{nullParameterType}' should not be null";

                throw new ArgumentNullException(nullParameterName, exceptionMessage);
            }
        }

        private void SolveSystem(double[,] systemOfEquations)
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
        }

        private double[] ComputeCoefficients(double[,] systemOfEquations)
        {
            var rowsCount = systemOfEquations.GetLength(0);
            var colsCount = systemOfEquations.GetLength(1);
            var coefficients = new double[rowsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                coefficients[row] = systemOfEquations[row, colsCount - 1] / systemOfEquations[row, row];
            }

            return coefficients;
        }

        private bool ShouldContinueProcessing(double b)
        {
            if (b.IsZero())
            {
                return false;
            }

            return true;
        }

        private double ComputeMultiplier(double a, double b)
        {
            double multiplier = 0d;
            double absoluteA = Math.Abs(a);
            double absoluteB = Math.Abs(b);

            if (absoluteA.IsGreaterThan(absoluteB))
            {
                multiplier = 1d / (absoluteA / absoluteB);
            }
            else
            {
                multiplier = absoluteB / absoluteA;
            }

            if (this.BothNumbersArePositive(a, b) || this.BothNumbersAreNegative(a, b))
            {
                multiplier *= -1d;
            }

            return multiplier;
        }

        private bool BothNumbersArePositive(double a, double b)
        {
            return a.IsPositive() && b.IsPositive();
        }

        private bool BothNumbersAreNegative(double a, double b)
        {
            return a.IsNegative() && b.IsNegative();
        }
    }
}
