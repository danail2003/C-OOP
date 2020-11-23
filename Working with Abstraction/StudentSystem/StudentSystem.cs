using System;
using System.Collections.Generic;

namespace P03_StudentSystem
{
    public class StudentSystem
    {
        private Dictionary<string, Student> repository;

        public StudentSystem()
        {
            this.repository = new Dictionary<string, Student>();
        }

        public void CreateOrShow(string[] command)
        {
            if (command[0] == "Create")
            {
                Create(command);
            }
            else if (command[0] == "Show")
            {
                Show(command);
            }
            else if (command[0] == "Exit")
            {
                Environment.Exit(0);
            }
        }

        public void Create(string[] command)
        {
            var name = command[1];
            var age = int.Parse(command[2]);
            var grade = double.Parse(command[3]);

            if (!repository.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                repository[name] = student;
            }
        }

        public void Show(string[] command)
        {
            var name = command[1];

            if (repository.ContainsKey(name))
            {
                var student = repository[name];
                string view = $"{student.Name} is {student.Age} years old.";

                if (student.Grade >= 5.00)
                {
                    view += " Excellent student.";
                }
                else if (student.Grade < 5.00 && student.Grade >= 3.50)
                {
                    view += " Average student.";
                }
                else
                {
                    view += " Very nice person.";
                }

                Console.WriteLine(view);
            }
        }
    }
}
