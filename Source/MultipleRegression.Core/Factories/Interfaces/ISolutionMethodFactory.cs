using MultipleRegression.Core.Interfaces;
using MultipleRegression.Core.SolutionMethods;

namespace MultipleRegression.Core.Factories.Interfaces
{
    public interface ISolutionMethodFactory
    {
        ISolutionMethod GetSolutionMethod(SolutionMethodType solutionMethod);
    }
}