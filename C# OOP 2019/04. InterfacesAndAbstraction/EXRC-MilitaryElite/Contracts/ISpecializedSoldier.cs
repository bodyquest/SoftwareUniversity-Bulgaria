using EXRC_MilitaryElite.Enumerations;

namespace EXRC_MilitaryElite.Contracts
{
    public interface ISpecializedSoldier: IPrivate
    {
        Corps Corps { get; }
    }
}
