using System.Collections.Generic;

namespace MultipleRegression.Core
{
    public interface IDataTableFormatter
    {
        decimal[,] Format(Dictionary<string, List<decimal>> dataTable);
    }
}
