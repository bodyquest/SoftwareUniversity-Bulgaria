using System;
using System.Text;
using System.Collections.Generic;

using EXRC_MilitaryElite.Contracts;
using EXRC_MilitaryElite.Enumerations;

namespace EXRC_MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly List<IRepair> repairs;

        public Engineer(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs => this.repairs;

        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString())
                .AppendLine("Repairs:");

            foreach (var rep in this.Repairs)
            {
                result.AppendLine($"  {rep.ToString()}");
            }

            return result.ToString().TrimEnd(); 
        }
    }
}
