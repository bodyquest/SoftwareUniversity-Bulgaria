using EXRC_MilitaryElite.Enumerations;

namespace EXRC_MilitaryElite.Contracts
{
    public interface IMission
    {
        string CodeName { get; }

        State State { get; }

        void CompleteMission();
    }
}
