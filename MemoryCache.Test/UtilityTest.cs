using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
namespace MemoryCache.Test
{
    [TestFixture]
    public class UtilityTest
    {
        private const int testNumbers = 10;

        [Test]
        public void TestIsPowerOfTwo_int_Success([Random(0, 30, 10)] int power)
        {
            int testNumber = (1 << power);
            Assert.True(testNumber.IsPowerOfTwo(), "Positive value");
            Assert.True((-testNumber).IsPowerOfTwo(),"negative value");
        }

        [Test]
        public void TestIsPowerOfTwo_uint_Success([Random(0, 31, 10)] int power)
        {
            uint testNumber = (uint)(1 << power);
            Assert.True(testNumber.IsPowerOfTwo(),"Positive value");
        }

        [Test]
        public void TestIsPowerOfTwo_long_Success([Random(0, 62, 10)] int power)
        {
            long testNumber = (1L << power);
            Assert.True(testNumber.IsPowerOfTwo(),"Positive value");
            Assert.True((-testNumber).IsPowerOfTwo(),"negative value");
        }

        [Test]
        public void TestIsPowerOfTwo_ulong_Success([Random(0, 63, 10)] int power)
        {
            ulong testNumber = (ulong)(1L << power);
            Assert.True(testNumber.IsPowerOfTwo(),"Positive value");
        }

        [Test]
        public void TestIsPowerOfTwo_ulong_Fail([ValueSource(nameof(ULongFailValues))]ulong number)
        {
            Assert.False(number.IsPowerOfTwo());
        }

        [Test]
        public void TestIsPowerOfTwo_long_Fail([ValueSource(nameof(LongFailValues))]long number)
        {
            Assert.False(number.IsPowerOfTwo());
        }

        [Test]
        public void TestIsPowerOfTwo_uint_Fail([ValueSource(nameof(UIntFailValues))]uint number)
        {
            Assert.False(number.IsPowerOfTwo());
        }

        [Test]
        public void TestIsPowerOfTwo_int_Fail([ValueSource(nameof(IntFailValues))]int number)
        {
            Assert.False(number.IsPowerOfTwo());
        }



        public static IEnumerable<ulong> ULongFailValues()
        {
            return NotPowersOfTwo(testNumbers, 63, false);
        }

        public static IEnumerable<long> LongFailValues()
        {
            return NotPowersOfTwo(testNumbers, 62, true).Select(l => (long) l);
        }

        public static IEnumerable<uint> UIntFailValues()
        {
            return NotPowersOfTwo(testNumbers, 30, false).Select(l => unchecked ((uint) l));
        }

        public static IEnumerable<int> IntFailValues()
        {
            return NotPowersOfTwo(testNumbers, 31, true).Select(l => unchecked ((int) l));
        }
        public static IEnumerable<ulong> NotPowersOfTwo(int amountNumbers, int maxDigits, bool sign)
        {
            var rnd = new Random();
            for (int i = 0; i < testNumbers; i++)
            {
                var digits = rnd.Next(2, maxDigits);
                var invert = false;
                if (digits > maxDigits / 2)
                {
                    digits -= maxDigits / 2;
                    invert = true;
                }

                var places = Enumerable.Range(1, maxDigits).ToList();
                ulong value = 0;
                for (int j = 0; j < digits; j++)
                {
                    var digit = places[rnd.Next((places.Count()))];
                    value |= (1UL << digit);
                    places.Remove((digit));
                }

                if (invert)
                {
                    value = ~value;
                }

                yield return value;
                if (sign)
                    yield return ~value + (ulong)(1L << (maxDigits > 31 ? 63 : 31));

            }
        }
    }
}

