using System;
using System.Collections.Generic;
using System.Text;

namespace Task2.Tests.Validation.ValidationRules
{
    public interface IValidationRule
    {
        public string GetMessage();

        public bool IsValid();
    }
}
