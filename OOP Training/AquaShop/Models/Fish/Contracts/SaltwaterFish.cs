﻿namespace AquaShop.Models.Fish.Contracts
{
    public class SaltwaterFish : Fish, IFish
    {
        private const int InitialSize = 5;

        public SaltwaterFish(string name, string species, decimal price)
            :base(name, species, price)
        {
            this.Size = InitialSize;
        }

        public override void Eat()
        {
            this.Size += 2;
        }
    }
}
