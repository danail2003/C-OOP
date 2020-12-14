using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaShop.Utilities.Messages;

namespace AquaShop.Models.Aquariums.Contracts
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private readonly List<IDecoration> decorations;
        private readonly List<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => this.decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fish;

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Capacity > this.fish.Count)
            {
                this.fish.Add(fish);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
        }

        public void Feed()
        {
            foreach (var currentFish in this.fish)
            {
                currentFish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{this.Name} ({this.GetType().Name}):");

            if (this.fish.Count > 0)
            {
                stringBuilder.AppendLine($"Fish: {string.Join(", ", this.fish.Select(x => x.Name))}");
            }
            else
            {
                stringBuilder.AppendLine("Fish: none");
            }

            stringBuilder.AppendLine($"Decorations: {this.Decorations.Count}");
            stringBuilder.AppendLine($"Comfort: {this.Comfort}");

            return stringBuilder.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }
    }
}
