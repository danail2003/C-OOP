using System.Text;

namespace CarsSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }

        public Engine(string model, int power, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
        }

        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat($" {this.Model}:\n");
            sb.AppendFormat($"  Power: {this.Power}\n");
            sb.AppendFormat($"  Displacement: {(this.Displacement == 0 ? "n/a" : this.Displacement.ToString())}\n");
            sb.AppendFormat($"  Efficiency: {(this.Efficiency == null ? "n/a" : Efficiency)}\n");

            return sb.ToString().TrimEnd();
        }
    }
}
