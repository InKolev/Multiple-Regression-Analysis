using System;
using System.Collections.Generic;
using System.Linq;
using MultipleRegression.Core.Formatters.Interfaces;

namespace MultipleRegression.Core.Formatters
{
    public class DataTableFormatter : IDataTableFormatter
    {
        public double[,] Format(Dictionary<string, List<double>> dataTable)
        {
            var criterionsNames = dataTable.Keys.ToList();
            var criterionsCount = criterionsNames.Count;
            var dataTableRowsCount = dataTable.First().Value.Count;

            var rowsCount = criterionsCount;
            var colsCount = criterionsCount + 1;

            var systemOfEquations = new double[rowsCount, colsCount];

            // Build first row
            systemOfEquations[0, 0] = dataTableRowsCount;
            for (int row = 0, col = 1; col < colsCount; col++)
            {
                var position = col - 1;
                var criterionName = criterionsNames[position];
                var criterionValues = dataTable[criterionName];
                var criterionSum = criterionValues.Sum();
                systemOfEquations[row, col] = criterionSum;
            }

            // Build first column
            for (int row = 1, col = 0; row < rowsCount; row++)
            {
                systemOfEquations[row, col] = systemOfEquations[col, row];
            }

            // Build remaining rows
            for (int row = 1; row < rowsCount; row++)
            {
                for (int col = 1; col < colsCount; col++)
                {
                    if (row == col)
                    {
                        var criterionName = criterionsNames[row - 1];
                        var sumOfSquares = dataTable[criterionName].Sum(x => x * x);
                        systemOfEquations[row, col] = sumOfSquares;
                    }
                    else
                    {
                        var firstCriterionName = criterionsNames[row - 1];
                        var secondCriterionName = criterionsNames[col - 1];
                        var sumOfCriterionsMultiplication = 
                            this.SumOfMultiplications(
                                dataTable[firstCriterionName],
                                dataTable[secondCriterionName]);
                        systemOfEquations[row, col] = sumOfCriterionsMultiplication;
                    }
                }
            }

            return systemOfEquations;
        }

        private double SumOfMultiplications(List<double> firstList, List<double> secondList)
        {
            if (firstList.Count != secondList.Count)
            {
                throw new InvalidOperationException("Cannot apply operation on sets of different magnitude");
            }

            double result = 0;

            checked
            {
                for (int i = 0; i < firstList.Count; i++)
                {
                    result += firstList[i] * secondList[i];
                }
            }

            return result;
        }

        private double SumElements(List<double> list)
        {
            var sum = default(double);

            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];
            }

            return sum;
        }
    }
}
