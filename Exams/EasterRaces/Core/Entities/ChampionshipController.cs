namespace EasterRaces.Core.Entities
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using EasterRaces.Utilities.Messages;
    using EasterRaces.Core.Contracts;
    using EasterRaces.Models.Drivers.Entities;
    using EasterRaces.Repositories.Entities;
    using EasterRaces.Models.Cars.Entities;
    using EasterRaces.Models.Cars.Contracts;
    using EasterRaces.Models.Drivers.Contracts;
    using EasterRaces.Models.Races.Contracts;
    using EasterRaces.Models.Races.Entities;

    public class ChampionshipController : IChampionshipController
    {
        private readonly DriverRepository driverRepository;

        private readonly RaceRepository raceRepository;

        private readonly CarRepository carRepository;

        public ChampionshipController()
        {
            this.carRepository = new CarRepository();
            this.raceRepository = new RaceRepository();
            this.driverRepository = new DriverRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            if (this.driverRepository.GetByName(driverName) == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            if (this.carRepository.GetByName(carModel) == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            ICar car = this.carRepository.GetByName(carModel);
            IDriver driver = this.driverRepository.GetByName(driverName);

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (this.raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (this.driverRepository.GetByName(driverName) == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            IDriver driver = this.driverRepository.GetByName(driverName);
            IRace race = this.raceRepository.GetByName(raceName);

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.carRepository.GetByName(model) != null)
            {
                throw new ArgumentException($"Car {model} is already created");
            }

            Car car = null;

            if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }
            else if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }

            this.carRepository.Add(car);

            return string.Format(OutputMessages.CarCreated, type, model);
        }

        public string CreateDriver(string driverName)
        {
            if (this.driverRepository.GetByName(driverName) != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            this.driverRepository.Add(new Driver(driverName));

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            IRace race = new Race(name, laps);

            this.raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            if (this.raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (this.driverRepository.GetAll().Count(x => x.CanParticipate) < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            List<IDriver> drivers = new List<IDriver>();
            StringBuilder stringBuilder = new StringBuilder();

            IRace removedRace = this.raceRepository.GetByName(raceName);

            foreach (var driver in removedRace.Drivers.OrderByDescending(x=>x.Car.CalculateRacePoints(removedRace.Laps)).Take(3))
            {
                drivers.Add(driver);
            }

            this.raceRepository.Remove(removedRace);

            int counter = 0;

            foreach (var driver in drivers)
            {
                if (counter == 0)
                {
                    stringBuilder.AppendLine($"Driver {driver.Name} wins {raceName} race.");
                    counter++;
                }
                else if (counter == 1)
                {
                    stringBuilder.AppendLine($"Driver {driver.Name} is second in {raceName} race.");
                    counter++;
                }
                else if (counter == 2)
                {
                    stringBuilder.AppendLine($"Driver {driver.Name} is third in {raceName} race.");
                    counter = 0;
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
