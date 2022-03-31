using System;
using System.Collections.Generic;
using System.Text;
using Task2.Tests.Validation.ValidationRules;

namespace Task2.Validation.ValidationRules.NumberParserRules
{
    public class IsSecondSymbolIsNumberRule : StringValidationRule
    {
        public IsSecondSymbolIsNumberRule(string stringValue)
            : base(stringValue)
        {
            message = "Second symbol is not a number!";
        }

        public override string GetMessage()
        {
            return message;
        }

        public override bool IsValid()
        {
            if (stringValue.Length > 1 && char.IsDigit(stringValue[1]))
                return true;
            return false;
        }
    }
}
