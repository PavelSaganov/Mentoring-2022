using System;
using System.Collections.Generic;

namespace BinarySerializaton.Models
{
    [Serializable]
    public class Department
    {
        public List<Employee> Employees { get; set; }
    }
}
