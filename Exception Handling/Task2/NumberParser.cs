using System;
using System.Linq;
using System.Text;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            int intValue = 0;

            if (stringValue is null)
                throw new ArgumentNullException();

            if (!string.IsNullOrWhiteSpace(stringValue)
                && (stringValue.All(character => char.IsDigit(character))
                || IsFirstSymbolIsPlusOrMinus(stringValue) && IsSecondSymbolIsNumber(stringValue)))
            {
                if (IsOutOfRangeAsInt(stringValue))
                    throw new OverflowException("Argument is out of range!");

                for (int i = 0; i < stringValue.Length; i++)
                {
                    if (char.IsDigit(stringValue[i]))
                    {
                        intValue *= 10;
                        intValue += stringValue[i] - '0';
                    }
                }

                // if negative
                if (stringValue[0] == '-')
                    intValue *= -1;

                return intValue;
            }
            else throw new FormatException("Inputed value is null or whitespace!");
        }

        private bool IsFirstSymbolIsPlusOrMinus(string str)
        {
            if (str[0] == '-' || str[0] == '+')
                return true;
            return false;
        }

        private bool IsSecondSymbolIsNumber(string str)
        {
            if (str.Length > 1 && char.IsDigit(str[1]))
                return true;
            return false;
        }

        private bool IsOutOfRangeAsInt(string str)
        {
            int lastNumberOfString = (str[str.Length - 1] - '0') % 10;

            if (IsFirstSymbolIsPlusOrMinus(str))
            {
                if (str.Length - 1 > int.MaxValue.ToString().Length || str.Length > int.MinValue.ToString().Length)
                    return true;

                if (IsSecondSymbolIsNumber(str))
                {
                    if (str.Length - 1 == int.MaxValue.ToString().Length)
                    {
                        if (str[0] == '+' && lastNumberOfString > int.MaxValue % 10)
                            return true;
                        if (str[0] == '-' && lastNumberOfString * -1 < int.MinValue % 10)
                            return true;
                    }
                }
                else return false;
            }
            else
            {
                if (str.Length > int.MaxValue.ToString().Length || str.Length > int.MinValue.ToString().Length)
                    return true;

                if (str.Length == int.MaxValue.ToString().Length && lastNumberOfString > int.MaxValue % 10)
                    return true;
            }

            return false;
        }
    }
}