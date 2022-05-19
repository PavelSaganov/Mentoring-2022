using System;
using System.Collections.Generic;
using System.IO;
using SerializationLibrary.Serializers.FileSerializers;
using XmlSerialization.Models;

namespace XmlSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var curDir = Directory.GetCurrentDirectory();
            var pathToFile = $"{curDir}//XmlDepartment.xml";

            var department = new Department()
            {
                Employees = new List<Employee>
                {
                    new Employee { Name = "Petr" },
                    new Employee { Name = "Valeriy" },
                    new Employee { Name = "Elena" },
                },
            };

            ShowEmployeesAndTextForEach(department, "was wrote to xml");

            XmlFileSerializer xmlFileSerializer = new XmlFileSerializer();
            xmlFileSerializer.Serialize($"{pathToFile}", department);
            var result = xmlFileSerializer.Deserialize<Department>($"{pathToFile}");

            if (result is Department)
            {
                ShowEmployeesAndTextForEach(result, "was read from xml");
            }

            Console.ReadKey();
        }

        public static void ShowEmployeesAndTextForEach(Department department, string text)
        {
            foreach (var employee in department.Employees)
            {
                Console.WriteLine($"{employee.Name} {text}");
            }
        }
    }
}
