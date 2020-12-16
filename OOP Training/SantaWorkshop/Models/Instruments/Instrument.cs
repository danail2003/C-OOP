namespace SantaWorkshop.Models.Instruments.Contracts
{
    public class Instrument : IInstrument
    {
        public Instrument(int power)
        {
            this.Power = power;
        }

        public int Power { get; private set; }

        public bool IsBroken()
        {
            return this.Power == 0;
        }

        public void Use()
        {
            if (this.Power - 10 < 0)
            {
                this.Power = 0;
            }
            else
            {
                this.Power -= 10;
            }
        }
    }
}
