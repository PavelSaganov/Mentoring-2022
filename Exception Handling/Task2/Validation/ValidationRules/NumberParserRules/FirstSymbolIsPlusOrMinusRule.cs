using System;
using System.Collections.Generic;
using System.Text;
using Task2.Tests.Validation.ValidationRules;

namespace Task2.Validation.ValidationRules.NumberParserRules
{
    public class FirstSymbolIsPlusOrMinusRule : StringValidationRule
    {
        public FirstSymbolIsPlusOrMinusRule(string stringValue)
            : base(stringValue)
        {
            message = "First symbol is not plus or minus!";
        }

        public override string GetMessage()
        {
            return message;
        }

        public override bool IsValid()
        {
            if (stringValue[0] == '-' || stringValue[0] == '+')
                return true;
            return false;
        }
    }
}
