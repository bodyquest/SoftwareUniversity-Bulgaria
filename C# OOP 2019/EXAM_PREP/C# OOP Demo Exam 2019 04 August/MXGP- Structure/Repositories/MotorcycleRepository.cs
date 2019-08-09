using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
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
