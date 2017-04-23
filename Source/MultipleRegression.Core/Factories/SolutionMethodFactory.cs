using MultipleRegression.Core.Factories.Interfaces;
using MultipleRegression.Core.Interfaces;
using MultipleRegression.Core.SolutionMethods;

namespace MultipleRegression.Core.Factories
{
    public class SolutionMethodFactory : ISolutionMethodFactory
    {
        public ISolutionMethod GetSolutionMethod(SolutionMethodType solutionMethod)
        {
            switch(solutionMethod)
            {
                case SolutionMethodType.GaussianElimination:
                    return new GaussianEliminationSolutionMethod();

                default:
                    return null;
            }
        }
    }
}
