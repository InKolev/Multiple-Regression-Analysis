namespace MultipleRegression.Core.Interfaces
{
    public interface ISolutionMethod
    {
        double[] Solve(double[,] systemOfEquations);
    }
}
