using System;
using System.Linq;
using System.Text;
using Task2.Validation.Validators;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            int intValue = 0;

            // TODO: make it as DI
            var validator = new NumberParseValidator(stringValue);

            if (validator.IsSuccess())
            {
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
            else validator.ThrowAllExceptions();

            return 0;
        }
    }
}