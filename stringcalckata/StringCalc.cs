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

            if (numbers.Contains("["))
            {
                string firstInstance = "[";
                string secondInstance = "]";
                
                string FinalString;
                int firstInstancePos = numbers.IndexOf(firstInstance) + firstInstance.Length;
                int secondInstancePos = numbers.IndexOf(secondInstance);
                var newdelimiter = numbers.Substring(firstInstancePos, secondInstancePos - firstInstancePos);

                
                
                


            }
            
            else if (numbers.Contains("//"))
            {
                char newDelimiter = numbers[DELIMITER_INDEX];
                delimiterList.Add(newDelimiter);
                numbers = numbers.Remove(0, 4);
            }

            var splitNumbers = numbers
                .Split(delimiterList.ToArray());

            List<string> splitNumbersList = new List<string>(splitNumbers);
            for (int pos = 0; pos < splitNumbersList.Count; pos++)
            {
                var value = splitNumbersList[pos];
                if (Int32.Parse(value) > 1000)
                {
                    splitNumbersList.RemoveAt(pos);
                }
            }

            splitNumbers = splitNumbersList.ToArray();

        return splitNumbers
                .Select(stringNumber => Convert.ToInt32(stringNumber))
                .Sum();

        }
    }
}
