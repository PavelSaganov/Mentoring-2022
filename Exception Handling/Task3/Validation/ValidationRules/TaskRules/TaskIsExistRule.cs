using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task3.DoNotChange;
using Task3.Validation.ValidationRules.UserRoles;
using Task3.Validation.ValidationRules.UserRules;

namespace Task3.Validation.ValidationRules.TaskRules
{
    public class TaskIsExistRule : IValidationRule
    {
        private readonly int _idOfUserTaskToFound;
        private readonly IUserDao _userDao;
        private readonly UserTask _task;
        private const string message = "The task is already exists";

        public TaskIsExistRule(int idOfUserTaskToFound, IUserDao userDao, UserTask task)
        {
            _idOfUserTaskToFound = idOfUserTaskToFound;
            _userDao = userDao;
            _task = task;
        }

        public string GetMessage()
        {
            return message;
        }

        public bool IsValid()
        {
            var idRule = new UserIdRule(_idOfUserTaskToFound);
            var userIsExistsRule = new UserFoundedInDaoRule(_userDao, _idOfUserTaskToFound);

            if (idRule.IsValid())
            {
                if (userIsExistsRule.IsValid())
                {
                    var user = _userDao.GetUser(_idOfUserTaskToFound);
                    return user.Tasks.All(t =>
                        !string.Equals(_task.Description, t.Description, StringComparison.OrdinalIgnoreCase));
                }
            }

            return true;
        }
    }
}
