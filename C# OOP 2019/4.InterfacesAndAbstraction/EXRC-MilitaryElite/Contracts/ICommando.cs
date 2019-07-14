using System.Collections.Generic;

namespace EXRC_MilitaryElite.Contracts
{
    public interface ICommando : ISpecializedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }

        void AddMission(IMission mission);
    }
}
