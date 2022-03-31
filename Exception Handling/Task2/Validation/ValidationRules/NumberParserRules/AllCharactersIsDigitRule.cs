using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task2.Tests.Validation.ValidationRules;

namespace Task2.Validation.ValidationRules.NumberParserRules
{
    public class AllCharactersIsDigitRule : StringValidationRule
    {
        public AllCharactersIsDigitRule(string stringValue)
            : base(stringValue)
        {
            message = "Not all characters are digit!";
        }

        public override string GetMessage()
        {
            return message;
        }

        public override bool IsValid()
        {
            return stringValue.All(character => char.IsDigit(character));
        }
    }
}
