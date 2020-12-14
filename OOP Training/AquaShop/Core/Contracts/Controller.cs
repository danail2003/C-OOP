using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaShop.Core.Contracts;
using AquaShop.Repositories.Contracts;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Core.Contracts
{
    public class Controller : IController
    {
        private DecorationRepository decorationRepository;
        private List<IAquarium> aquaria;

        public Controller()
        {
            this.decorationRepository = new DecorationRepository();
            this.aquaria = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if(aquariumType != nameof(FreshwaterAquarium) && aquariumType != nameof(SaltwaterAquarium))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            if (aquariumType == nameof(SaltwaterAquarium))
            {
                this.aquaria.Add(new SaltwaterAquarium(aquariumName));
            }
            else if (aquariumType == nameof(FreshwaterAquarium))
            {
                this.aquaria.Add(new FreshwaterAquarium(aquariumName));
            }

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            if(decorationType != nameof(Plant) && decorationType != nameof(Ornament))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            if (decorationType == nameof(Ornament))
            {
                this.decorationRepository.Add(new Ornament());
            }
            else if (decorationType == nameof(Plant))
            {
                this.decorationRepository.Add(new Plant());
            }

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if(fishType != nameof(SaltwaterFish) && fishType != nameof(FreshwaterFish))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IAquarium aquarium = this.aquaria.First(x => x.Name == aquariumName);

            if(aquarium.GetType().Name == nameof(SaltwaterAquarium) && fishType == nameof(FreshwaterFish) || aquarium.GetType().Name == nameof(FreshwaterAquarium) && fishType == nameof(SaltwaterFish))
            {
                return string.Format(OutputMessages.UnsuitableWater);
            }

            if (fishType == nameof(FreshwaterFish))
            {
                aquarium.AddFish(new FreshwaterFish(fishName, fishSpecies, price));
            }
            else
            {
                aquarium.AddFish(new SaltwaterFish(fishName, fishSpecies, price));
            }

            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquaria.First(x => x.Name == aquariumName);

            decimal value = aquarium.Decorations.Sum(x => x.Price) + aquarium.Fish.Sum(x => x.Price);

            return string.Format(OutputMessages.AquariumValue, aquariumName, $"{value:f2}");
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquaria.First(x => x.Name == aquariumName);
            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            if (this.decorationRepository.FindByType(decorationType) == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            IAquarium aquarium = this.aquaria.First(x => x.Name == aquariumName);
            IDecoration decoration = this.decorationRepository.FindByType(decorationType);

            aquarium.AddDecoration(decoration);

            this.decorationRepository.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var aquarium in this.aquaria)
            {
                stringBuilder.AppendLine(string.Join(Environment.NewLine, aquarium.GetInfo()));
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
