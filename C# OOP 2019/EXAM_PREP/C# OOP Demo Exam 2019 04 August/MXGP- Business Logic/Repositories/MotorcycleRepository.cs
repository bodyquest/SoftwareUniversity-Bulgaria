namespace MXGP.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using MXGP.Repositories.Contracts;
    using MXGP.Models.Motorcycles.Contracts;

    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private readonly IList<IMotorcycle> repo;

        public MotorcycleRepository()
        {
            this.repo = new List<IMotorcycle>();
        }
        public void Add(IMotorcycle model)
        {
            this.repo.Add(model);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            return this.repo.ToList();
        }

        public IMotorcycle GetByName(string name)
        {
            return this.repo.FirstOrDefault(m => m.Model == name);
        }

        public bool Remove(IMotorcycle model)
        {
            return this.repo.Remove(model);
        }
    }
}
