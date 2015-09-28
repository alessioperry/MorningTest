using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xunit;

namespace Test
{
    public class UnitTest
    {
        private readonly Dictionary<Int32, Dictionary<Int32, string>> _storage = new Dictionary
            <Int32, Dictionary<Int32, string>>()
        {
            {
                0, new Dictionary<int, string>()
                {
                    {0, ""},
                    {1, "One"},
                    {2, "Two"},
                    {5, "Five"}
                }
            },
            {
                1, new Dictionary<int, string>()
                {
                    {2, "Twenty"},
                    {3, "Tirty"},
                    {4, "Forty"},
                }
            },
            {
                2, new Dictionary<int, string>()
                {
                    {1, "OneHundred"},
                    {2, "TwoHundred"},
                    {3, "ThreeHundred"},
                    
                }
            }
        };

        [Fact]
        public void IsZero()
        {
            Assert.Equal("Zero", SayTheNumber(0));
        }

        [Fact]
        public void IsOne()
        {
            Assert.Equal("One", SayTheNumber(1));
        }

        [Fact]
        public void IsTwo()
        {
            Assert.Equal("Two", SayTheNumber(2));
        }

        [Fact]
        public void IsTwentyOne()
        {
            Assert.Equal("TwentyOne", SayTheNumber(21));
        }

        [Fact]
        public void IsTwentyTwo()
        {
            Assert.Equal("TwentyTwo", SayTheNumber(22));
        }

        [Fact]
        public void IsTwenty()
        {
            Assert.Equal("Twenty", SayTheNumber(20));
        }

        [Fact]
        public void IsOneHundredFortyFive()
        {
            Assert.Equal("OneHundredFortyFive", SayTheNumber(145));
        }

        private string SayTheNumber(Int32 number)
        {

            if (number == 0)
                return "Zero";

            var digitArray = ConvertNumberToDigitArray(number);

            var result = new StringBuilder();
            
            for (var count = 0; count <= digitArray.Count() - 1; count++)
            {
               var tempDictionary = _storage[count];
               result.Insert(0, tempDictionary[digitArray[count]]);
            }

            return result.ToString();
        }

        static Int32[] ConvertNumberToDigitArray(Int32 num)
        {
            var digitArray = new Int32[num.ToString(CultureInfo.InvariantCulture).Length];

            Int32 pointer = 0;

            while (num > 0)
            {
                digitArray[pointer] = num%10;
                num = num / 10;
                pointer++;
            }
            return digitArray;
        }
    }
}

