namespace MilitaryElite
{
    public class Repair
    {
        public Repair(string partName, int hours)
        {
            this.PartName = partName;
            this.Hours = hours;
        }

        public string PartName { get; set; }

        public int Hours { get; set; }

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.Hours}";
        }
    }
}
