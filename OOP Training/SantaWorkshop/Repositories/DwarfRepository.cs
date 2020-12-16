namespace SantaWorkshop.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using SantaWorkshop.Repositories.Contracts;
    using SantaWorkshop.Models.Dwarfs.Contracts;

    public class DwarfRepository : IRepository<IDwarf>
    {
        private readonly List<IDwarf> dwarves;

        public DwarfRepository()
        {
            this.dwarves = new List<IDwarf>();
        }

        public IReadOnlyCollection<IDwarf> Models => this.dwarves.AsReadOnly();

        public void Add(IDwarf model)
        {
            this.dwarves.Add(model);
        }

        public IDwarf FindByName(string name)
        {
            return this.dwarves.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IDwarf model)
        {
            return this.dwarves.Remove(model);
        }
    }
}
