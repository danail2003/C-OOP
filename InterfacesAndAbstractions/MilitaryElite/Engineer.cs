using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : ISoldier, IPrivate, ISpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, Corps corps)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Corps = corps;
            this.Salary = salary;
            this.Repairs = new List<Repair>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Corps Corps { get; }

        public decimal Salary { get; set; }

        public List<Repair> Repairs { get; private set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            stringBuilder.AppendLine($"Corps: {this.Corps}");
            stringBuilder.AppendLine("Repairs:");

            foreach (var repair in this.Repairs)
            {
                stringBuilder.AppendLine($"  {repair.ToString()}");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
