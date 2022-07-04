using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public static class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            ValidateNegativeNumbers(numbers);

            var delimeter = GetDelimeterAndRemoveItFromString(ref numbers);
            var splittedNumbers = GetSplittedNumbersWithDelimeter(numbers, delimeter);
            var sum = GetSumOfSplittedNumbers(splittedNumbers);

            return sum;
        }

        private static int GetSumOfSplittedNumbers(string[] splittedNumbers)
        {
            int sum = 0;
            foreach (string number in splittedNumbers)
            {
                if (IsNumber(number) && number.Length < 4)
                    sum += Convert.ToInt32(number);
            }

            return sum;
        }

        private static void ValidateNegativeNumbers(string numbers)
        {
            var listOfNegative = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (IsNumber(numbers[i].ToString())
                    && i > 0
                    && numbers[i - 1] == '-')
                {
                    listOfNegative.Add(int.Parse(numbers[i].ToString()));
                }
            }

            if (listOfNegative.Any())
            {
                var messageBuilder = new StringBuilder("Negatives not allowed:");
                foreach (var negative in listOfNegative)
                {
                    messageBuilder.Append($" -{negative}");
                }

                throw new FormatException(messageBuilder.ToString());
            }
        }

        private static bool IsNumber(string number)
        {
            return number.All(n => char.IsDigit(n));
        }

        private static string[] GetSplittedNumbersWithDelimeter(string numbers, string[] delimeter)
        {
            var splittedNumbers = numbers.Split(delimeter, StringSplitOptions.None);

            for (int i = 0; i < splittedNumbers.Length; i++)
            {
                splittedNumbers[i] = splittedNumbers[i].Replace("\n", string.Empty);
            }

            return splittedNumbers;
        }

        private static string[] GetDelimeterAndRemoveItFromString(ref string numbers)
        {
            var delimeters = new List<string>();

            while (numbers.Contains('['))
            {
                int startIndexOfDelimeters = numbers.IndexOf('[');
                int endIndexOfDelimeters = numbers.IndexOf(']');

                delimeters.Add(numbers.Substring(startIndexOfDelimeters + 1, endIndexOfDelimeters - startIndexOfDelimeters - 1));
                numbers = numbers.Remove(startIndexOfDelimeters, endIndexOfDelimeters - startIndexOfDelimeters + 1);
            }

            if (delimeters.Any())
                return delimeters.ToArray();

            string[] delimeter = new string[] { "," };
            if (!char.IsDigit(numbers[0]))
            {
                delimeter = new string[] { numbers[0].ToString() };
                numbers = numbers.Substring(1);
            }

            return delimeter;
        }
    }
}
