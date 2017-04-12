using System;
using System.Collections.Generic;
using System.Linq;

namespace MultipleRegression.Core
{
    public class DataTableToSystemOfEquationsFormatter
    {
        public decimal[,] Format(Dictionary<string, List<decimal>> dataTable)
        {
            var criterionsNames = dataTable.Keys.ToList();
            var criterionsCount = criterionsNames.Count;
            var dataTableRowsCount = dataTable.First().Value.Count;

            var rowsCount = criterionsCount;
            var colsCount = criterionsCount + 1;

            var systemOfEquations = new decimal[rowsCount, colsCount];

            // Build first equation
            systemOfEquations[0, 0] = dataTableRowsCount;
            for (int row = 0, col = 1; col < colsCount; col++)
            {
                var position = col - 1;
                var criterionName = criterionsNames[position];
                var criterionValues = dataTable[criterionName];
                var criterionSum = criterionValues.Sum();
                systemOfEquations[row, col] = criterionSum;
            }

            // Build next N - 1 equations
            for (int row = 1; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    if (col == 0)
                    {
                        var criterionKeyForSum = criterionsNames[row - 1];
                        var criterionSum = dataTable[criterionKeyForSum].Sum();
                        systemOfEquations[row, col] = criterionSum;
                        continue;
                    }

                    if (row == col)
                    {
                        var criterionKeyForSquare = criterionsNames[row - 1];
                        var criterionSquaredSum = dataTable[criterionKeyForSquare].Sum(x => x * x);
                        systemOfEquations[row, col] = criterionSquaredSum;
                    }
                    else
                    {
                        var firstCriterionKeyForMultiply = criterionsNames[row - 1];
                        var secondCriterionKeyForMultiply = criterionsNames[col - 1];
                        var criterionSumOfMultiplications = this.SumOfMultiplications(dataTable[firstCriterionKeyForMultiply], dataTable[secondCriterionKeyForMultiply]);
                        systemOfEquations[row, col] = criterionSumOfMultiplications;
                    }
                }
            }

            return systemOfEquations;
        }

        private decimal SumOfMultiplications(List<decimal> firstList, List<decimal> secondList)
        {
            if (firstList.Count != secondList.Count)
            {
                throw new InvalidOperationException("Cannot apply operation on sets of different magnitude");
            }

            decimal result = 0;

            checked
            {
                for (int i = 0; i < firstList.Count; i++)
                {
                    result += firstList[i] * secondList[i];
                }
            }

            return result;
        }

        private decimal SumElements(List<decimal> list)
        {
            var sum = default(decimal);

            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];
            }

            return sum;
        }
    }
}
