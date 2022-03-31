using System;
using System.Collections.Generic;
using System.Text;
using Task2.Tests.Validation.ValidationRules;

namespace Task2.Validation.ValidationRules.NumberParserRules
{
    public class IsOutOfRangeAsIntRule : StringValidationRule
    {
        public IsOutOfRangeAsIntRule(string stringValue)
            : base(stringValue)
        {
            message = "Converted value is out of range!";
        }

        public override string GetMessage()
        {
            return message;
        }

        public override bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(stringValue))
                return true;

            int lastNumberOfString = (stringValue[stringValue.Length - 1] - '0') % 10;

            if (stringValue[0] == '-' || stringValue[0] == '+')
            {
                if (stringValue.Length - 1 > int.MaxValue.ToString().Length || stringValue.Length > int.MinValue.ToString().Length)
                    return false;

                if (stringValue.Length > 1 && char.IsDigit(stringValue[1]))
                {
                    if (stringValue.Length - 1 == int.MaxValue.ToString().Length)
                    {
                        if (stringValue[0] == '+' && lastNumberOfString > int.MaxValue % 10)
                            return false;
                        if (stringValue[0] == '-' && lastNumberOfString * -1 < int.MinValue % 10)
                            return false;
                    }
                }
                else return true;
            }
            else
            {
                if (stringValue.Length > int.MaxValue.ToString().Length || stringValue.Length > int.MinValue.ToString().Length)
                    return false;

                if (stringValue.Length == int.MaxValue.ToString().Length && lastNumberOfString > int.MaxValue % 10)
                    return false;
            }

            return true;
        }
    }
}
