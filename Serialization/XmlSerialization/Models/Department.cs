using System.Collections.Generic;
namespace XmlSerialization.Models
{
    public class Department
    {
        public Department()
        {

        }

        public List<Employee> Employees { get; set; }
    }
}
