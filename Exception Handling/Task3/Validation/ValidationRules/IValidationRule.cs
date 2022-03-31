using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Validation.ValidationRules
{
    public interface IValidationRule
    {
        public string GetMessage();

        public bool IsValid();
    }
}
