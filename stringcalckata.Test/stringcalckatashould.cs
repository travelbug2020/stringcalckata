using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace stringcalckata.Test
{
    public class Tests
    {
        private StringCalc stringCalc;
        [SetUp]
        public void Setup()
        { 
            stringCalc = new StringCalc();
        }

        [Test]
        public void Return0_WhenAddingNoNumbers_GivenEmptyString()
        {
            var result = stringCalc.Add("");

            Assert.AreEqual(0,result);
        }

        [TestCase("1",1)]
        [TestCase("0,1",1)]
        [TestCase("1,2",3)]
        [TestCase("10,1",11)]
        [TestCase("150,50,50",250)]
        public void ReturnSum_WhenAddingCommaSeparatedList_GivenNumbers(string numbers, int expectedResult)
        {
            var result = stringCalc.Add(numbers);
            
            Assert.AreEqual(expectedResult,result);
        }

        [TestCase("3\n60", 63)]
        [TestCase("300\n301\n5\n10", 616)]
        public void ReturnSum_WhenAddingNewLineSeparatedList_GivenNumbers(string numbers, int expectedResult)
        {
            var result = stringCalc.Add(numbers);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("1\n2,3", 6)]
        [TestCase("5\n10,8", 23)]
        public void ReturnSum_WhenAddingSeparatedList_GivenNumbers(string numbers, int expectedResult)
        {
            var result = stringCalc.Add(numbers);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("//;2;3",5)]
        public void ReturnSum_WhenDefiningSeparatorInList_GivenNumbers(string numbers, int expectedResult)
        {
            var result = stringCalc.Add(numbers);

            Assert.AreEqual(expectedResult, result);
        }
    }
}