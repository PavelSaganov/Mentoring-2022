using System;
using System.Collections.Generic;
using System.Text;
using Task2.Tests.Validation.ValidationRules;

namespace Task2.Validation.ValidationRules.NumberParserRules
{
    public class IsCorrectFormatRule : StringValidationRule
    {
        public IsCorrectFormatRule(string stringValue)
            : base(stringValue)
        {
            message = "Incorrect format!";
        }

        public override string GetMessage()
        {
            return message;
        }

        public override bool IsValid()
        {
            if (stringValue is null)
                return true;

            var allCharactersIsDigitRule = new AllCharactersIsDigitRule(stringValue);
            var firstSymbolIsPlusOrMinusRule = new FirstSymbolIsPlusOrMinusRule(stringValue);
            var isSecondSymbolIsNumberRule = new IsSecondSymbolIsNumberRule(stringValue);
            var nullOrWhiteSpaceRule = new NullOrWhiteSpaceRule(stringValue);

            if (nullOrWhiteSpaceRule.IsValid()
                && (allCharactersIsDigitRule.IsValid()
                    || (firstSymbolIsPlusOrMinusRule.IsValid() && isSecondSymbolIsNumberRule.IsValid())))
                return true;

            return false;
        }
    }
}
