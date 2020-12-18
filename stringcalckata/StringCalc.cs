using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace stringcalckata
{
    public class StringCalc
    {
        public int Add(string numbers)
        {
            string[] splitString = { };
            char newDelimiter = new char();

            if (numbers == string.Empty)
            {
                return 0;
            }
            
            List<char> delimiterList = new List<char>();
            delimiterList.Add('\n');
            delimiterList.Add(',');

            if (numbers.Contains("//"))
            {
                newDelimiter = numbers[2];
                delimiterList.Add(newDelimiter);
                numbers = numbers.Remove(0, 3);
                splitString = numbers.Split(delimiterList.ToArray());
            }
            else
            {
                splitString = numbers.Split(delimiterList.ToArray());
            }
           
            
            //List<char> delimiterList = new List<char>();
            //if (delimiterIndex != -1)
            //{
                
            //    delimiterList = new List<char>();
            //    char delimiter = numbers[delimiterIndex + 2];
            //    char[] sep = new char[',''\n''delimiter'];
            //    splitString = numbers.Split(',','\n','{delimiter}');
            //    var paramSeparator = "',', '\n', {delimiter}";
            //    numbers.Remove(numbers[0], 2);
            //}


            var arrayOfNumbers = splitString.Select(stringNumber => Convert.ToInt32(stringNumber))
                .ToArray();
            
            

            return arrayOfNumbers.Sum();

        }
    }
}
