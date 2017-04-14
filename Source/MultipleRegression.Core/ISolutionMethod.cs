namespace MultipleRegression.Core
{
    public interface ISolutionMethod
    {
        decimal[] Solve(decimal[,] systemOfEquations);
    }
}
