using System;
using System.Collections.Generic;
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
                    {1, "Onehundred"},
                    {2, "twohundred"},
                    {3, "Threehundred"},
                    
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

        private string SayTheNumber(Int32 number)
        {

            if (number == 0)
                return "Zero";

            var numberTolist = convertNumberToList(number);

            var result = new StringBuilder();

            var enumerable = numberTolist as int[] ?? numberTolist.ToArray();

            for (var count = 0; count <= enumerable.Count() - 1; count++)
            {
               var tempDictionary = _storage[count];
               result.Insert(0, tempDictionary[enumerable[count]]);
            }

            return result.ToString();
        }

        static IEnumerable<int> convertNumberToList(int num)
        {
            var listOfInts = new List<int>();

            int[] local = { 1, 2, 3 };

            while (num > 0)
            {
                listOfInts.Add(num % 10);
                num = num / 10;
            }

            return listOfInts;
        }
    }
}

//745.00 $ (amount in numbers)
//seven hundred and fourty five dollars (amount in words)

