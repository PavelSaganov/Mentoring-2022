using System.Collections.Generic;
using Task3.DoNotChange;

namespace Task3.Validators
{
    public interface IUserValidator
    {
        public IUserDao UserDao { get; set; }

        public List<string> Messages { get; set; }

        public bool IsValid(int userId);
    }
}
