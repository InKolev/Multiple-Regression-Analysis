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

            for (int i = 0; i < rowsCount; i++)
            {

            }
            return new decimal[2];
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
            decimal aAbsoluteValue = Math.Abs(a);
            decimal bAbsoluteValue = Math.Abs(b);

            decimal multiplier = 0m;
            if (aAbsoluteValue > bAbsoluteValue)
            {
                multiplier = 1m / (aAbsoluteValue / bAbsoluteValue);
            }
            else if (aAbsoluteValue < bAbsoluteValue)
            {
                multiplier = bAbsoluteValue / aAbsoluteValue;
            }

            // Decide subtraction or addition
            if (b.IsZero())
            {
                // skip and continue with next rows
            }
            else if ((b.IsPositive() && a.IsPositive()) ||
                (b.IsNegative() && a.IsNegative()))
            {
                multiplier *= -1m;
            }

            return multiplier;
        }
    }
}
