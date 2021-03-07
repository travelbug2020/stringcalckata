using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Threading;

namespace stringcalckata
{
    public class StringCalc
    {
        private const int DELIMITER_INDEX = 2;

        public int Add(string numbers)
        {

            if (numbers.Contains("-"))
            {
                throw new NegativesNotAllowed();
            }

            if (numbers == string.Empty)
            {
                return 0;
            }

            var delimiterList = new List<char> { '\n', ',' };
            var delimiterListWithBrackets = new List<string> {};
            List<string> splitNumberList;
            if (numbers.Contains("["))
            {
                GetDelimiterFromBrackets(numbers, delimiterListWithBrackets);
                string[] newStringArrayOfNumbers = numbers.Split('\n');
                var newStringOfNumbers = newStringArrayOfNumbers[1];
                var splitNumber = newStringOfNumbers.Split(delimiterListWithBrackets.ToArray(), StringSplitOptions.RemoveEmptyEntries);
                splitNumberList = CheckNumbersAreSmallerThan1000(splitNumber);
                splitNumber = splitNumberList.ToArray();

                return splitNumber
                    .Select(stringNumber => Convert.ToInt32(stringNumber))
                    .Sum();

            }
            if (numbers.Contains("//"))
            {
                var newDelimiter = numbers[DELIMITER_INDEX];
                delimiterList.Add(newDelimiter);
                numbers = numbers.Remove(0, 4);
            }

            var splitNumbers = numbers
                .Split(delimiterList.ToArray());
            splitNumberList = CheckNumbersAreSmallerThan1000(splitNumbers);
            splitNumbers = splitNumberList.ToArray();

        return splitNumbers
                .Select(stringNumber => Convert.ToInt32(stringNumber))
                .Sum();
        }

        public List<string> CheckNumbersAreSmallerThan1000(string[] stringToCheck)
        {
            List<string> splitNumbersList = new List<string>(stringToCheck);
            for (var pos = 0; pos < splitNumbersList.Count; pos++)
            {
                var value = splitNumbersList[pos];
                if (Int32.Parse(value) > 1000)
                {
                    splitNumbersList.RemoveAt(pos);
                }
            }
            return splitNumbersList;
        }

        public string GetDelimiterFromBrackets(string stringToCheck, List<string> listOfDelimiters)
        {
            if (stringToCheck.Contains("["))
            {
                string openingBracket = "[";
                string closingBracket = "]";
                int openingBracketIndex = stringToCheck.IndexOf(openingBracket);
                int closingBracketIndex = stringToCheck.IndexOf(closingBracket);
                var newDelimiter = stringToCheck.Substring(openingBracketIndex + 1, closingBracketIndex - openingBracketIndex - 1);
                listOfDelimiters.Add(newDelimiter);
                List<char> tempList = stringToCheck.ToList();
                for (var index = openingBracketIndex; index <= closingBracketIndex; index++)
                {
                    tempList.RemoveAt(openingBracketIndex);
                }
                stringToCheck = new string(tempList.ToArray());
                GetDelimiterFromBrackets(stringToCheck, listOfDelimiters);
            }
            return stringToCheck;
        }
    }
}
