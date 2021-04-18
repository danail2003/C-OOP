namespace EasterRaces.Models.Cars.Entities
{
    using EasterRaces.Models.Cars.Contracts;

    public class SportsCar : Car, ICar
    {
        private const double cubicCentimeters = 3000;

        private const int minHP = 250;

        private const int maxHP = 450;

        public SportsCar(string model, int horsePower)
            :base(model, horsePower, cubicCentimeters, minHP, maxHP)
        {

        }
    }
}
