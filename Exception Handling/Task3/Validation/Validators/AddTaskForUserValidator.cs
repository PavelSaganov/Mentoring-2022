using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task3.CustomExceptions;
using Task3.DoNotChange;
using Task3.Validation.ValidationRules;
using Task3.Validation.ValidationRules.UserRoles;
using Task3.Validation.ValidationRules.TaskRules;
using Task3.Validation.ValidationRules.UserRules;

namespace Task3.Validation.Validators
{
    public class AddTaskForUserValidator : IValidator
    {
        public AddTaskForUserValidator(int userId, UserTask task, IUserDao userDao)
        {
            Rules = new List<IValidationRule>
            {
                new UserIdRule(userId),
                new UserFoundedInDaoRule(userDao, userId),
                new TaskIsExistRule(userId, userDao, task)
            };
        }

        public AddTaskForUserValidator(List<IValidationRule> customRules, string stringValue)
        {
            Rules = customRules;
        }

        public List<IValidationRule> Rules { get; set; }

        public bool IsSuccess()
        {
            var success = true;

            foreach (var rule in Rules)
            {
                if (!rule.IsValid())
                    success = false;
            }

            return success;
        }

        public void ThrowAllExceptions()
        {
            var notPassedRules = Rules.Where(r => !r.IsValid());

            foreach (var rule in notPassedRules)
            {
                var ruleType = rule.GetType();
                var ruleMessage = rule.GetMessage();

                // Can't use switch - must use constant value
                if (ruleType.Equals(typeof(UserIdRule)))
                    throw new NegativeIdException(ruleMessage);

                if (HaveTypeOfRule(notPassedRules, typeof(UserFoundedInDaoRule)))
                    throw new ObjectNotFoundException(ruleMessage);

                if (HaveTypeOfRule(notPassedRules, typeof(TaskIsExistRule)))
                    throw new AlreadyExistsException(ruleMessage);
            }
        }

        private bool HaveTypeOfRule(IEnumerable<IValidationRule> collectionOfRules, Type typeOfRule)
        {
            return collectionOfRules.FirstOrDefault(r => r.GetType().Equals(typeOfRule)) != null;
        }
    }
}
