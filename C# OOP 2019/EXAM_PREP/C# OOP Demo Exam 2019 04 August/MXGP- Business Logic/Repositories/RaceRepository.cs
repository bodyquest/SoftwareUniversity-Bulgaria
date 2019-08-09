using System.Linq;
using System.Collections.Generic;

using MXGP.Models.Races.Contracts;
using MXGP.Repositories.Contracts;

namespace MXGP.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly IList<IRace> repo;

        public RaceRepository()
        {
            this.repo = new List<IRace>();
        }

        public void Add(IRace model)
        {
            this.repo.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.repo.ToList();
        }

        public IRace GetByName(string name)
        {
            return this.repo.FirstOrDefault(m => m.Name == name);
        }

        public bool Remove(IRace model)
        {
            return this.repo.Remove(model);
        }
    }
}
