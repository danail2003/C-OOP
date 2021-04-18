namespace EasterRaces.Models.Cars.Entities
{
    using EasterRaces.Models.Cars.Contracts;

    public class MuscleCar : Car, ICar
    {
        private const double cubicCentimeters = 5000;

        private const int minHP = 400;

        private const int maxHP = 600;

        public MuscleCar(string model, int horsePower)
            :base(model, horsePower, cubicCentimeters, minHP, maxHP)
        {

        }
    }
}
