using System;
using System.Collections.Generic;
using System.IO;
using JsonSerialization.Models;
using SerializationLibrary.Serializers.FileSerializers;

namespace JsonSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var curDir = Directory.GetCurrentDirectory();
            var pathToFile = $"{curDir}//JsonDepartment.json";

            var department = new Department()
            {
                Employees = new List<Employee>
                {
                    new Employee { Name = "Petr" },
                    new Employee { Name = "Valeriy" },
                    new Employee { Name = "Elena" },
                },
            };

            ShowEmployeesAndTextForEach(department, "was wrote to json");

            var jsonFileSerializer = new JsonFileSerializer();
            jsonFileSerializer.Serialize(pathToFile, department);
            var result = jsonFileSerializer.Deserialize<Department>($"{pathToFile}");

            if (result is Department)
            {
                ShowEmployeesAndTextForEach(result, "was read from json");
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
