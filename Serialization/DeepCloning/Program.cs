using System;
using System.Collections.Generic;

namespace DeepCloning
{
    class Program
    {
        static void Main(string[] args)
        {
            var department = new Department()
            {
                Employees = new List<Employee>
                {
                    new Employee { Name = "Petr" },
                    new Employee { Name = "Valeriy" },
                    new Employee { Name = "Elena" },
                },
            };

            ShowEmployeesAndTextForEach(department, "is clonning...");

            var cloner = new Cloner();
            var clonedDepartment = cloner.DeepClone(department);
            
            ShowEmployeesAndTextForEach(clonedDepartment, "was cloned");

            Console.WriteLine($"It's independent instances: {IndependentObjects(department, clonedDepartment)}");

            Console.ReadKey();
        }

        public static void ShowEmployeesAndTextForEach(Department department, string text)
        {
            foreach (var employee in department.Employees)
            {
                Console.WriteLine($"{employee.Name} {text}");
            }
        }

        public static bool IndependentObjects(Department department1, Department department2)
        {
            if (department1 != department2)
            {
                for (int i = 0; i < department1.Employees.Count; i++)
                {
                    if (department1.Employees[i] == department2.Employees[i])
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
