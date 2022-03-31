using System;
using System.Collections.Generic;
using System.Text;
using Task3.DoNotChange;

namespace Task3.Validation.ValidationRules.UserRules
{
    public class UserFoundedInDaoRule : IValidationRule
    {
        private readonly IUserDao _userDao;
        private readonly int _userId;
        private const string message = "User not found";

        public UserFoundedInDaoRule(IUserDao userDao, int userId)
        {
            _userDao = userDao;
            _userId = userId;
        }

        public string GetMessage()
        {
            return message;
        }

        public bool IsValid()
        {
            return _userDao.GetUser(_userId) != null;
        }
    }
}
