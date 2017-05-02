using System;
using MultipleRegression.Core.Factories.Interfaces;
using MultipleRegression.Core.Interfaces;
using MultipleRegression.Core.SolutionMethods;

namespace MultipleRegression.Core.Factories
{
    public class SolutionMethodFactory : ISolutionMethodFactory
    {
        public ISolutionMethod GetSolutionMethod(SolutionMethodType solutionMethod)
        {
            switch (solutionMethod)
            {
                case SolutionMethodType.GaussianElimination:
                    return new GaussianEliminationSolutionMethod();

                default:
                    throw new NotSupportedException($"The factory does not provide solution method of type {(int)solutionMethod}");
            }
        }
    }
}
