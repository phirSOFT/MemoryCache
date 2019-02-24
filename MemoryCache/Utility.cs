namespace MemoryCache
{
    internal static class Utility
    {
        public static bool IsPowerOfTwo(this int number)
        {
            return (number >= 0 ? (number & (number - 1)) :  (~number & (~number - 1))) == 0;
        }

        public static bool IsPowerOfTwo(this uint number)
        {
            return (number & (number - 1)) == 0;
        }

        public static bool IsPowerOfTwo(this long number)
        {
            return (number >= 0 ? (number & (number - 1)) :  (~number & (~number - 1))) == 0;
        }

        public static bool IsPowerOfTwo(this ulong number)
        {
            return (number & (number - 1)) == 0;
        }
    }
}
