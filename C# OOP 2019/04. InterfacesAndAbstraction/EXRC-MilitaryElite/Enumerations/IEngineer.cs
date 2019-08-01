using System.Collections.Generic;

using EXRC_MilitaryElite.Contracts;

namespace EXRC_MilitaryElite.Enumerations
{
    public interface IEngineer : ISpecializedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }

        void AddRepair(IRepair repair);
    }
}
