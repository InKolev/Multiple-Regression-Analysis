namespace MultipleRegression.Core
{
    public interface ISolutionMethodFactory
    {
        ISolutionMethod GetSolutionMethod(SolutionMethod solutionMethod);
    }
}