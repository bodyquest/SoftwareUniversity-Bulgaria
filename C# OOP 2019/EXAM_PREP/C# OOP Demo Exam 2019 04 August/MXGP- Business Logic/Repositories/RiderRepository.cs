namespace MXGP.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using MXGP.Repositories.Contracts;
    using MXGP.Models.Riders.Contracts;

    public class RiderRepository : IRepository<IRider>
    {
        private readonly IList<IRider> repo;

        public RiderRepository()
        {
            this.repo = new List<IRider>();
        }

        public void Add(IRider model)
        {
            this.repo.Add(model);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            return this.repo.ToList();
        }

        public IRider GetByName(string name)
        {
            return this.repo.FirstOrDefault(m => m.Name == name);
        }

        public bool Remove(IRider model)
        {
            return this.repo.Remove(model);
        }
    }
}
