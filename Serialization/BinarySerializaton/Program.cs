using System;
using System.Collections.Generic;
using System.IO;
using BinarySerializaton.Models;
using SerializationLibrary.Serializers.FileSerializers;

namespace BinarySerializaton
{
    public class Program
    {
        static void Main(string[] args)
        {
            var curDir = Directory.GetCurrentDirectory();
            var pathToFile = $"{curDir}//BinDepartment.bin";

            var department = new Department()
            {
                Employees = new List<Employee>
                {
                    new Employee { Name = "Petr" },
                    new Employee { Name = "Valeriy" },
                    new Employee { Name = "Elena" },
                },
            };

            ShowEmployeesAndTextForEach(department, "was wrote to bin");

            var binFileSerializer = new BinaryFileSerializer();
            binFileSerializer.Serialize(pathToFile, department);
            var result = binFileSerializer.Deserialize<Department>($"{pathToFile}");

            if (result is Department)
            {
                ShowEmployeesAndTextForEach(result, "was read from json bin");
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
