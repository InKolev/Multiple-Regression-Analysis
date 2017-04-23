using System.Collections.Generic;

namespace MultipleRegression.Core.Formatters.Interfaces
{
    public interface IDataTableFormatter
    {
        double[,] Format(Dictionary<string, List<double>> dataTable);
    }
}
