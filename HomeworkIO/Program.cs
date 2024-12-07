using HomeworkIO;
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "data.txt";

        var student = new Student { Id = 1, Name = "Anna", Age = 21 };
        var employee = new Employee { Id = 1, Name = "Lilit", Position = "Developer" };
        var university = new University { Id = 1, Name = "Nelly", Location = "Abovyan" };

        WriteToFile(filePath, student);
        WriteToFile(filePath, employee);
        WriteToFile(filePath, university);

        ReadFromFile(filePath);
    }

    public static void WriteToFile(string filePath, object obj)
    {
        string objectType = obj.GetType().Name;

        var propertyValues = obj.GetType().GetProperties()
                               .Select(p => p.GetValue(obj)?.ToString());

        string line = objectType + " " + string.Join(" ", propertyValues);

        File.AppendAllText(filePath, line + Environment.NewLine);
    }


    public static void ReadFromFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            string[] parts = line.Split(' ');
            string type = parts[0];

            if (type == "Student")
            {
                Console.WriteLine($"Student: Id={parts[1]}, Name={parts[2]}, Age={parts[3]}");
            }
            else if (type == "Employee")
            {
                Console.WriteLine($"Employee: Id={parts[1]}, Name={parts[2]}, Position={parts[3]}");
            }
            else if (type == "University")
            {
                Console.WriteLine($"University: Id={parts[1]}, Name={parts[2]}, Location={parts[3]}");
            }
        }
    }
}

