namespace SantaWorkshop.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using SantaWorkshop.Models.Presents.Contracts;
    using SantaWorkshop.Repositories.Contracts;

    public class PresentRepository : IRepository<IPresent>
    {
        private readonly List<IPresent> presents;

        public PresentRepository()
        {
            this.presents = new List<IPresent>();
        }

        public IReadOnlyCollection<IPresent> Models => this.presents.AsReadOnly();

        public void Add(IPresent model)
        {
            this.presents.Add(model);
        }

        public IPresent FindByName(string name)
        {
            return this.presents.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IPresent model)
        {
            return this.presents.Remove(model);
        }
    }
}
