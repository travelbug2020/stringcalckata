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

            var delimiterList = new List<char> {'\n', ','};
            List<string> splitNumberList;
            if (numbers.Contains("["))
            {
                int indexOfFirstNumber;
                int indexOfSecondNumber;
                int indexOfNewLineCharacter;
                int delimiterLength;
                string openingBracket = "[";
                string closingBracket = "]";
                int openingBracketIndex = numbers.IndexOf(openingBracket); 
                int closingBracketIndex = numbers.IndexOf(closingBracket); 
                var newdelimiter = numbers.Substring(openingBracketIndex + 1, closingBracketIndex - openingBracketIndex - 1);
                indexOfNewLineCharacter = numbers.IndexOf('\n');
                string[] newStringArrayOfNumbers = numbers.Split('\n');
                var newStringOfNumbers = newStringArrayOfNumbers[1];
                var splitNumber = newStringOfNumbers.Split(newdelimiter);
                splitNumberList = CheckNumbersAreSmallerThan1000(splitNumber);
                splitNumber = splitNumberList.ToArray();

                return splitNumber
                    .Select(stringNumber => Convert.ToInt32(stringNumber))
                    .Sum();

            }
            if (numbers.Contains("//"))
            {
                char newDelimiter = numbers[DELIMITER_INDEX];
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
            for (int pos = 0; pos < splitNumbersList.Count; pos++)
            {
                var value = splitNumbersList[pos];
                if (Int32.Parse(value) > 1000)
                {
                    splitNumbersList.RemoveAt(pos);
                }
            }

            return splitNumbersList;
        }
    }
}
