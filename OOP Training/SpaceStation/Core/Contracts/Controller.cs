namespace SpaceStation.Core.Contracts
{
    using System.Linq;
    using SpaceStation.Models.Mission;
    using System;
    using System.Text;
    using SpaceStation.Repositories.Contracts;
    using SpaceStation.Models.Planets;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Utilities.Messages;
    using SpaceStation.Models.Astronauts;

    public class Controller : IController
    {
        private readonly AstronautRepository astronautRepository;
        private readonly PlanetRepository planetRepository;
        private readonly Mission mission;
        private int exploredPlanets = 0;

        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
            this.mission = new Mission();
            this.exploredPlanets = 0;
        }

        public string AddAstronaut(string type, string astronautName)
        {
            if(type != nameof(Biologist) && type != nameof(Geodesist) && type != nameof(Meteorologist))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            if (type == nameof(Geodesist))
            {
                this.astronautRepository.Add(new Geodesist(astronautName));
            }
            else if (type == nameof(Biologist))
            {
                this.astronautRepository.Add(new Biologist(astronautName));
            }
            else
            {
                this.astronautRepository.Add(new Meteorologist(astronautName));
            }

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            this.planetRepository.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            var suitableAstronauts = this.astronautRepository.Models.Where(x => x.Oxygen > 60);

            if (suitableAstronauts == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            IPlanet planet = this.planetRepository.FindByName(planetName);
            
            this.mission.Explore(planet, suitableAstronauts.ToList());
            this.exploredPlanets++;

            return string.Format(OutputMessages.PlanetExplored, planetName, astronautRepository.Models.Where(x=>x.CanBreath == false).Count());
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{this.exploredPlanets} planets were explored!");
            stringBuilder.AppendLine("Astronauts info:");

            foreach (var astronaut in this.astronautRepository.Models)
            {
                stringBuilder.AppendLine($"Name: {astronaut.Name}");
                stringBuilder.AppendLine($"Oxygen: {astronaut.Oxygen}");

                if (astronaut.Bag.Items.Count == 0)
                {
                    stringBuilder.AppendLine("Bag items: none");
                }
                else
                {
                    stringBuilder.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)}");
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            if (this.astronautRepository.FindByName(astronautName) == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }

            IAstronaut astronaut = this.astronautRepository.FindByName(astronautName);

            this.astronautRepository.Remove(astronaut);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
