namespace MultipleRegression.Core.ExtensionMethods
{
    public static class DecimalExtensionMethods
    {
        private const decimal Zero = 0m;

        public static bool IsPositive(this decimal number)
        {
            return number > Zero;
        }

        public static bool IsNegative(this decimal number)
        {
            return number < Zero;
        }

        public static bool IsZero(this decimal number)
        {
            return number == Zero;
        }
    }
}
