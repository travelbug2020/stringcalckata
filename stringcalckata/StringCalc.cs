using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace stringcalckata
{
    public class StringCalc
    {
        public int Add(string numbers)
        {
            if (numbers == string.Empty)
            {
                return 0;
            }

            var delimiterIndex = numbers.IndexOf("//");
            var splitString = numbers.Split(',', '\n');
            List<char> delimiterList = new List<char>();
            if (delimiterIndex != -1)
            {
                
                delimiterList = new List<char>();
                char delimiter = numbers[delimiterIndex + 2];
                char[] sep = new char[',''\n''delimiter'];
                splitString = numbers.Split(',','\n','{delimiter}');
                paramSeparator = "',', '\n', {delimiter}";
                numbers.Remove(numbers[0], 2);
            }


            var arrayOfNumbers = splitString.Select(stringNumber => Convert.ToInt32(stringNumber))
                .ToArray();
            
            

            return arrayOfNumbers.Sum();

        }
    }
}
