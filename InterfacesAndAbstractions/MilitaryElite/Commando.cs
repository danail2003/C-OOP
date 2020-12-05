using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Commando : ISoldier, IPrivate, ISpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, Corps corps)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.Corps = corps;
            this.Missions = new List<Mission>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }

        public Corps Corps { get; set; }

        public List<Mission> Missions { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            stringBuilder.AppendLine($"Corps: {this.Corps}");
            stringBuilder.AppendLine("Missions:");

            foreach (var mission in Missions)
            {
                stringBuilder.AppendLine(mission.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
