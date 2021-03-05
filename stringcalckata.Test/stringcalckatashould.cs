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

        [TestCase("//;\n2;3",5)]
        [TestCase("//;\n2;3\n5",10)]
        public void ReturnSum_WhenDefiningSeparatorInList_GivenNumbers(string numbers, int expectedResult)
        {
            var result = stringCalc.Add(numbers);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("-2")]
        [TestCase("-3")]
        [TestCase("-3,5")]
        public void ReturnException_WhenInputHas_NegativeNumbers(string numbers)
        {
            Assert.Throws<NegativesNotAllowed>(() => { stringCalc.Add(numbers);});
        }

        [TestCase("1001",0)]
        [TestCase("1003",0)]
        [TestCase("1003,5,3,2",10)]
        public void ReturnSum_WhenIgnoring_BigNumbers(string numbers, int expectedResult)
        {
            var result = stringCalc.Add(numbers);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("//[**]\n1**1", 2)]
        [TestCase("//[**]\n1**2", 3)]
        [TestCase("//[**]\n1**3", 4)]
        [TestCase("//[**]\n1**3**1", 5)]
        [TestCase("//[***]\n1***3***1", 5)]
        public void ReturnSum_WhenIgnoring_SizeOfDelimiter(string numbers, int expectedResult)
        {
            var result = stringCalc.Add(numbers);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("//[*][%]\n1*1%1", 3)]
        public void ReturnSum_AllowingMultiple_Delimiters(string numbers, int expectedResult)
        {
            var result = stringCalc.Add(numbers);

            Assert.AreEqual(expectedResult, result);
        }
    }
}