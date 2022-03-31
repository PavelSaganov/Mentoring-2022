using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Validation.Validators
{
    public interface IValidator
    {
        public bool IsSuccess();

        public void ThrowAllExceptions();
    }
}
