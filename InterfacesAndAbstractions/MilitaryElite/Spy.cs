using System.Text;

namespace MilitaryElite
{
    public class Spy : ISoldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; set; }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");
            stringBuilder.AppendLine($"Code Number: {this.CodeNumber}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
