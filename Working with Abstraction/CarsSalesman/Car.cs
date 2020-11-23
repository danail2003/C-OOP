using System.Text;

namespace CarsSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = -1;
            this.Color = "n/a";
        }

        public Car(string model, Engine engine, int weight)
            :this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            :this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            :this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }

        public Engine Engine { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat($"{this.Model}:\n");
            sb.Append($"{this.Engine.ToString()}\n");
            sb.AppendFormat($" Weight: {(this.Weight == -1 ? "n/a" : this.Weight.ToString())}\n");
            sb.AppendFormat($" Color: {(this.Color == null ? "n/a" : Color)}");

            return sb.ToString();
        }
    }
}
