using System;
using System.Collections.Generic;
using System.Text;

namespace Task2.Tests.Validation.ValidationRules
{
    public abstract class StringValidationRule : IValidationRule
    {
        protected string message;
        protected string stringValue;

        public StringValidationRule(string stringValue)
        {
            this.stringValue = stringValue;
        }

        public abstract string GetMessage();

        public abstract bool IsValid();
    }
}
