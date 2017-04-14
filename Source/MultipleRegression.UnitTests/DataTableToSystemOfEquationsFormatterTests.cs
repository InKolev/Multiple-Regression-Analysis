using System.Collections.Generic;
using MultipleRegression.Core;
using NUnit.Framework;

namespace MultipleRegression.UnitTests
{
    [TestFixture]
    public class DataTableToSystemOfEquationsFormatterTests
    {
        [Test]
        public void Format_WhenPassedValidDataTable_ReturnsCorrectlyComputedSystemOfEquations()
        {
            var dataTable = this.GetDataTable();
            var expectedSystemOfEquations = this.GetSystemOfEquations();
            var formatter = new DataTableToSystemOfEquationsFormatter();

            var actualSystemOfEquations = formatter.Format(dataTable);

            Assert.AreEqual(expectedSystemOfEquations, actualSystemOfEquations);
        }

        private Dictionary<string, List<decimal>> GetDataTable()
        {
            return new Dictionary<string, List<decimal>>()
            {
                {"w", new List<decimal> { 1142m, 863m, 1065m, 554m, 983m, 256m } },
                {"x", new List<decimal> { 1060m, 995m, 3205m, 120m, 2896m, 485m } },
                {"y", new List<decimal> { 325m, 98m, 23m, 0m, 120m, 88m } },
                {"z", new List<decimal> { 201m, 98m, 162m, 54m, 138m, 61m } }
            };
        }

        private decimal[,] GetSystemOfEquations()
        {
            return new decimal[,]
            {
                { 6, 4863, 8761, 654, 714 },
                { 4863, 4521899, 8519938, 620707, 667832 },
                { 8761, 8519938, 21022091, 905925, 1265493 },
                { 654, 620707, 905925, 137902, 100583 }
            };
        }
    }
}
