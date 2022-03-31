using System;
using Task2.Tests.Validation.ValidationRules;

namespace Task2.Validation.ValidationRules.CommonRules
{
    public class ArgumentNullRule : IValidationRule
    {
        private readonly object _argument;
        private const string message = "Inputed parameter is null!";

        public ArgumentNullRule(object argument)
        {
            _argument = argument;
        }

        public string GetMessage()
        {
            return message;
        }

        public bool IsValid()
        {
            return _argument is null;
        }
    }
}
