﻿using System;
using System.Collections.Generic;
using System.Text;
using Task2.Tests.Validation.ValidationRules;

namespace Task2.Validation.Validators
{
    public interface IValidator
    {
        public bool IsSuccess();

        public void ThrowAllExceptions();
    }
}
