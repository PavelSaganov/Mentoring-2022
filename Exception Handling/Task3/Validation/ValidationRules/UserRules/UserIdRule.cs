using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Validation.ValidationRules.UserRoles
{
    public class UserIdRule : IValidationRule
    {
        private readonly int _id;
        private const string message = "Invalid userId";

        public UserIdRule(int id)
        {
            _id = id;
        }

        public string GetMessage()
        {
            return message;
        }

        public bool IsValid()
        {
            return _id > 0;
        }
    }
}
