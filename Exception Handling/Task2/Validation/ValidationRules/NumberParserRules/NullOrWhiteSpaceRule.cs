using System;
using System.Collections.Generic;
using System.Text;
using Task2.Tests.Validation.ValidationRules;

namespace Task2.Validation.ValidationRules.NumberParserRules
{
    public class NullOrWhiteSpaceRule : StringValidationRule
    {
        public NullOrWhiteSpaceRule(string stringValue)
            : base(stringValue)
        {
            message = "Value is null or whitespace!";
        }

        public override string GetMessage()
        {
            return message;
        }

        public override bool IsValid()
        {
            return string.IsNullOrWhiteSpace(stringValue);
        }
    }
}
