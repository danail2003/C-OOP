namespace SantaWorkshop.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using SantaWorkshop.Core.Contracts;
    using SantaWorkshop.Models.Dwarfs;
    using SantaWorkshop.Models.Dwarfs.Contracts;
    using SantaWorkshop.Models.Presents.Contracts;
    using SantaWorkshop.Repositories;
    using SantaWorkshop.Utilities.Messages;
    using SantaWorkshop.Models.Instruments.Contracts;
    using SantaWorkshop.Models.Presents;

    public class Controller : IController
    {
        private readonly DwarfRepository dwarfRepository;
        private readonly PresentRepository presentRepository;
        private readonly Workshop workshop;
        private int count;

        public Controller()
        {
            this.dwarfRepository = new DwarfRepository();
            this.presentRepository = new PresentRepository();
            this.workshop = new Workshop();
            this.count = 0;
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            if(dwarfType != nameof(SleepyDwarf) && dwarfType != nameof(HappyDwarf))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }

            if (dwarfType == nameof(SleepyDwarf))
            {
                this.dwarfRepository.Add(new SleepyDwarf(dwarfName));
            }
            else
            {
                this.dwarfRepository.Add(new HappyDwarf(dwarfName));
            }

            return string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            IDwarf dwarf = this.dwarfRepository.FindByName(dwarfName);

            if (dwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }

            dwarf.AddInstrument(new Instrument(power));

            return string.Format(OutputMessages.InstrumentAdded, power, dwarfName);
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            this.presentRepository.Add(new Present(presentName, energyRequired));

            return string.Format(OutputMessages.PresentAdded, presentName);
        }

        public string CraftPresent(string presentName)
        {
            ICollection<IDwarf> suitableDwarves = this.dwarfRepository.Models.Where(x => x.Energy >= 50).OrderByDescending(x=>x.Energy).ToList();

            if (!suitableDwarves.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }

            IPresent present = this.presentRepository.FindByName(presentName);

            while (suitableDwarves.Any())
            {
                IDwarf dwarf = suitableDwarves.First();
                this.workshop.Craft(present, dwarf);

                if (dwarf.Energy <= 0)
                {
                    this.dwarfRepository.Remove(dwarf);
                    suitableDwarves.Remove(dwarf);
                }

                if (!dwarf.Instruments.Any())
                {
                    suitableDwarves.Remove(dwarf);
                }

                if (present.IsDone())
                {
                    count++;
                    return string.Format(OutputMessages.PresentIsDone, presentName);
                }
            }

            return string.Format(OutputMessages.PresentIsNotDone, presentName);
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{count} presents are done!");
            stringBuilder.AppendLine($"Dwarfs info:");

            foreach (var dwarf in this.dwarfRepository.Models)
            {
                stringBuilder.AppendLine($"Name: {dwarf.Name}");
                stringBuilder.AppendLine($"Energy: {dwarf.Energy}");

                int countOfDoesntBroken = dwarf.Instruments.Where(x => x.Power > 0).Count();

                stringBuilder.AppendLine($"Instruments: {countOfDoesntBroken} not broken left");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
