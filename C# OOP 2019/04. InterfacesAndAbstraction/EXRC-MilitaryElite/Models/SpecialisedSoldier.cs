using System;

using EXRC_MilitaryElite.Contracts;
using EXRC_MilitaryElite.Exceptions;
using EXRC_MilitaryElite.Enumerations;

namespace EXRC_MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecializedSoldier
    {

        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            ParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private void ParseCorps(string corpsStr)
        {
            Corps corps;
            bool parsed = Enum.TryParse<Corps>(corpsStr, out corps);

            if (!parsed)
            {
                throw new InvalidCorpsException();
            }

            this.Corps = corps;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {this.Corps}";
        }
    }
}
