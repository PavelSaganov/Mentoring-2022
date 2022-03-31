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
            Rules = new List<IValidationRule>
            {
                new ArgumentNullRule(stringValue),
                new NullOrWhiteSpaceRule(stringValue),
                new IsCorrectFormatRule(stringValue),
                new IsOutOfRangeAsIntRule(stringValue)
            };

            _stringValue = stringValue;
        }

        public NumberParseValidator(List<IValidationRule> customRules, string stringValue)
        {
            Rules = customRules;
            _stringValue = stringValue;
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

                if (HaveTypeOfRule(notPassedRules, typeof(IsCorrectFormatRule)))
                    throw new FormatException(ruleMessage);

                if (HaveTypeOfRule(notPassedRules, typeof(IsOutOfRangeAsIntRule)))
                    throw new OverflowException(ruleMessage);
            }
        }

        private bool HaveTypeOfRule(IEnumerable<IValidationRule> collectionOfRules, Type typeOfRule)
        {
            return collectionOfRules.FirstOrDefault(r => r.GetType().Equals(typeOfRule)) != null;
        }
    }
}
