namespace MultipleRegression.Core
{
    public class SolutionMethodFactory
    {
        public ISolutionMethod GetSolutionMethod(SolutionMethod solutionMethod)
        {
            switch(solutionMethod)
            {
                case SolutionMethod.GaussianEliminationMethod:
                    return new GaussianEliminationMethod();

                default:
                    return null;
            }
        }
    }
}
