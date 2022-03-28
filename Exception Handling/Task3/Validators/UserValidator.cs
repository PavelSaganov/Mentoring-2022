using System.Collections.Generic;
using System.Linq;
using Task3.DoNotChange;

namespace Task3.Validators
{
    public class UserValidator : IUserValidator
    {
        

        public UserValidator(IUserDao UserDao)
        {

        }

        public List<string> Messages { get; set; } = new List<string>();

        public IUserDao UserDao { get; set; }

        public bool IsValid(int userId)
        {
            if (Messages.Any())
                Messages.Clear();

            if (userId < 0)
                return false;

            var user = UserDao.GetUser(userId);
            if (user == null)
                return false;

            return true;
        }
    }
}
