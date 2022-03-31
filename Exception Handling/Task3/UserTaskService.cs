using System;
using Task3.CustomExceptions;
using Task3.DoNotChange;
using Task3.Validation.Validators;

namespace Task3
{
    public class UserTaskService
    {
        private readonly IUserDao _userDao;
        private readonly IValidator _validator;

        public UserTaskService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public int AddTaskForUser(int userId, UserTask task)
        {
            var validator = new AddTaskForUserValidator(userId, task, _userDao);
            if (validator.IsSuccess())
            {
                var user = _userDao.GetUser(userId);
                var tasks = user.Tasks;
                tasks.Add(task);
            }
            else validator.ThrowAllExceptions();

            return 0;
        }
    }
}