using System;
using System.Collections.Generic;
using System.IO;
using SerializationLibrary.Serializers.FileSerializers;

namespace ISerializableImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var curDir = Directory.GetCurrentDirectory();
            var pathToFile = $"{curDir}//BinDepartment.bin";

            var employees = new List<Employee>()
            {
                new Employee()
                {
                    Age = 15,
                    Name = "Alena"
                },
                new Employee()
                {
                    Age = 29,
                    Name = "Sergey"
                },
                new Employee()
                {
                    Age = 38,
                    Name = "Bacho"
                },
            };

            ShowEmployeesAndTextForEach(employees, "was wrote to bin");

            var binFileSerializer = new BinaryFileSerializer();
            binFileSerializer.Serialize(pathToFile, employees);
            var result = binFileSerializer.Deserialize<List<Employee>>($"{pathToFile}");

            if (result is List<Employee>)
            {
                ShowEmployeesAndTextForEach(result, "was read from bin");
            }

            Console.ReadKey();
        }

        public static void ShowEmployeesAndTextForEach(List<Employee> employees, string text)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Name} {text}");
            }
        }
    }
}
