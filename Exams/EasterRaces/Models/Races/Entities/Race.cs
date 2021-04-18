﻿namespace EasterRaces.Models.Races.Entities
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using EasterRaces.Models.Drivers.Contracts;
    using EasterRaces.Models.Races.Contracts;

    public class Race : IRace
    {
        private string name;

        private int laps;

        private readonly List<IDriver> drivers;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.drivers = new List<IDriver>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if(string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }

                this.name = value;
            }
        }

        public int Laps
        {
            get => this.laps;
            private set
            {
                if(value < 1)
                {
                    throw new ArgumentException($"Laps cannot be less than 1.");
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this.drivers.AsReadOnly();

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("Driver cannot be null.");
            }

            if (!driver.CanParticipate)
            {
                throw new ArgumentException($"Driver {driver.Name} could not participate in race.");
            }

            if(this.drivers.FirstOrDefault(x=>x.Name==driver.Name) != null)
            {
                throw new ArgumentNullException($"Driver {driver.Name} is already added in {this.Name} race.");
            }

            this.drivers.Add(driver);
        }
    }
}
