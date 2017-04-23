namespace MultipleRegression.Core.Extensions
{
    public static class DoubleExtensionMethods
    {
        private const double Zero = 0d;

        public static bool IsPositive(this double a)
        {
            return a > Zero;
        }

        public static bool IsNegative(this double a)
        {
            return a < Zero;
        }

        public static bool IsZero(this double a)
        {
            return a == Zero;
        }

        public static bool IsGreaterThan(this double a, double b)
        {
            return a > b;
        }

        public static bool IsLessThan(this double a, double b)
        {
            return a < b;
        }
    }
}
