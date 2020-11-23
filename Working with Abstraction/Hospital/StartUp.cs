using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();

            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] token = command.Split();
                string department = token[0];
                string firstName = token[1];
                string secondName = token[2];
                string patient = token[3];
                string fullName = firstName + secondName;

                if (!doctors.ContainsKey(firstName + secondName))
                {
                    doctors[fullName] = new List<string>();
                }

                if (!departments.ContainsKey(department))
                {
                    departments[department] = new List<List<string>>();

                    AddingDepartments(departments, department);
                }

                bool isEmpty = departments[department].SelectMany(x => x).Count() < 60;

                if (isEmpty)
                {
                    int room = 0;
                    doctors[fullName].Add(patient);

                    for (int i = 0; i < departments[department].Count; i++)
                    {
                        if (departments[department][i].Count < 3)
                        {
                            room = i;
                            break;
                        }
                    }

                    departments[department][room].Add(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                PrintingPatients(command, departments, doctors);

                command = Console.ReadLine();
            }
        }

        public static void AddingDepartments(Dictionary<string, List<List<string>>> departments, string department)
        {
            for (int rooms = 0; rooms < 20; rooms++)
            {
                departments[department].Add(new List<string>());
            }
        }

        public static void PrintingPatients(string command, Dictionary<string, List<List<string>>> departments, Dictionary<string, List<string>> doctors)
        {
            string[] commands = command.Split();

            if (commands.Length == 1)
            {
                Console.WriteLine(string.Join("\n", departments[commands[0]].Where(x => x.Count > 0).SelectMany(x => x)));
            }
            else if (commands.Length == 2 && int.TryParse(commands[1], out int room))
            {
                Console.WriteLine(string.Join("\n", departments[commands[0]][room - 1].OrderBy(x => x)));
            }
            else
            {
                Console.WriteLine(string.Join("\n", doctors[commands[0] + commands[1]].OrderBy(x => x)));
            }
        }
    }
}
