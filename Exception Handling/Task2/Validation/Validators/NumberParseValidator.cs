using System;
using System.Collections.Generic;
using System.Linq;
using Task2.Tests.Validation.ValidationRules;
using Task2.Validation.ValidationRules.CommonRules;
using Task2.Validation.ValidationRules.NumberParserRules;

namespace Task2.Validation.Validators
{
    public class NumberParseValidator : IValidator
    {
        private readonly string _stringValue;

        public NumberParseValidator(string stringValue)
        {
            Rules.Add(new ArgumentNullRule(stringValue));
            Rules.Add(new NullOrWhiteSpaceRule(stringValue));
            Rules.Add(new AllCharactersIsDigitRule(stringValue));
            Rules.Add(new FirstSymbolIsPlusOrMinusRule(stringValue));
            Rules.Add(new IsSecondSymbolIsNumberRule(stringValue));
            Rules.Add(new IsOutOfRangeAsIntRule(stringValue));
        }

        public NumberParseValidator(List<IValidationRule> customRules)
        {
            Rules = customRules;
        }

        public List<IValidationRule> Rules { get; set; }

        public bool IsSuccess()
        {
            var success = true;

            foreach (var rule in Rules)
            {
                if (!rule.IsValid())
                    success = false;
            }

            return success;
        }

        public void ThrowAllExceptions()
        {
            var notPassedRules = Rules.Where(r => !r.IsValid());

            foreach (var rule in notPassedRules)
            {
                var ruleType = rule.GetType();
                var ruleMessage = rule.GetMessage();

                // Can't use switch - must use constant value
                if (ruleType.Equals(typeof(ArgumentNullRule)))
                {
                    throw new ArgumentNullException(nameof(_stringValue), ruleMessage);
                }

                if (ruleType.Equals(typeof(NullOrWhiteSpaceRule))
                    && (ruleType.Equals(typeof(AllCharactersIsDigitRule)) || ruleType.Equals(typeof(FirstSymbolIsPlusOrMinusRule)))
                    && ruleType.Equals(typeof(IsSecondSymbolIsNumberRule)))
                {
                    throw new FormatException(ruleMessage);
                }

                if (ruleType.Equals(typeof(IsOutOfRangeAsIntRule)))
                    throw new OverflowException(ruleMessage);
            }
        }
    }
}
