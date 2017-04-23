using System.Collections.Generic;
using MultipleRegression.Core.Formatters;
using NUnit.Framework;

namespace MultipleRegression.UnitTests
{
    [TestFixture]
    public class DataTableToSystemOfEquationsFormatterTests
    {
        private DataTableFormatter dataTableFormatter;

        [SetUp]
        public void TestSetup()
        {
            this.dataTableFormatter = new DataTableFormatter();
        }

        [Test]
        public void Format_WhenPassedValidDataTable_ReturnsCorrectlyComputedSystemOfEquations()
        {
            var dataTable = this.GetDataTable();
            var expectedSystemOfEquations = this.GetExpectedSystemOfEquations();

            var actualSystemOfEquations = this.dataTableFormatter.Format(dataTable);

            Assert.AreEqual(expectedSystemOfEquations, actualSystemOfEquations);
        }

        private Dictionary<string, List<double>> GetDataTable()
        {
            return new Dictionary<string, List<double>>()
            {
                {"w", new List<double> { 1142, 863, 1065, 554, 983, 256 } },
                {"x", new List<double> { 1060, 995, 3205, 120, 2896, 485 } },
                {"y", new List<double> { 325, 98d, 23d, 0d, 120, 88d } },
                {"z", new List<double> { 201, 98d, 162, 54d, 138, 61d } }
            };
        }

        private double[,] GetExpectedSystemOfEquations()
        {
            return new double[,]
            {
                { 6, 4863, 8761, 654, 714 },
                { 4863, 4521899, 8519938, 620707, 667832 },
                { 8761, 8519938, 21022091, 905925, 1265493 },
                { 654, 620707, 905925, 137902, 100583 }
            };
        }
    }
}
