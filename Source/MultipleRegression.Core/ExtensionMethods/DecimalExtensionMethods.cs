namespace MultipleRegression.Core.ExtensionMethods
{
    public static class DecimalExtensionMethods
    {
        private const decimal Zero = 0m;

        public static bool IsPositive(this decimal a)
        {
            return a > Zero;
        }

        public static bool IsNegative(this decimal a)
        {
            return a < Zero;
        }

        public static bool IsZero(this decimal a)
        {
            return a == Zero;
        }

        public static bool IsGreaterThan(this decimal a, decimal b)
        {
            return a > b;
        }

        public static bool IsLessThan(this decimal a, decimal b)
        {
            return a < b;
        }
    }
}
