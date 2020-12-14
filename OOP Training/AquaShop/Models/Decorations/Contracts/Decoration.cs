﻿namespace AquaShop.Models.Decorations.Contracts
{
    public abstract class Decoration : IDecoration
    {
        protected Decoration(int comfort, decimal price)
        {
            this.Comfort = comfort;
            this.Price = price;
        }

        public int Comfort { get; private set; }

        public decimal Price { get; private set; }
    }
}
