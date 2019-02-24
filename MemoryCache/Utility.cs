using System;

namespace MemoryCache
{
    internal static class Utility
    {
        public static bool IsPowerOfTwo(this int number)
        {
            return number < 0 ? IsPowerOfTwo((uint)-number) : IsPowerOfTwo((uint) number);
        }

        public static bool IsPowerOfTwo(this uint number)
        {
            return number <=2  ||(number & (number - 1)) == 0;
        }

        public static bool IsPowerOfTwo(this long number)
        {
            return number < 0 ? IsPowerOfTwo((ulong)-number) : IsPowerOfTwo((ulong) number);
        }

        public static bool IsPowerOfTwo(this ulong number)
        {
            
            return number <=2  || (number & (number - 1)) == 0;
        }
    }
}
