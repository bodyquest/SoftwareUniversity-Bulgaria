namespace EXRC_MilitaryElite.Models
{
    using System.Text;
    using System.Collections.Generic;

    using EXRC_MilitaryElite.Contracts;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly List<ISoldier> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<ISoldier>();
        }

        public IReadOnlyCollection<ISoldier> Privates => this.privates;

        public void AddPrivate(ISoldier @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString())
                .AppendLine("Privates: ");

            foreach (var pr in this.Privates)
            {
                result.AppendLine($"  {pr.ToString().TrimEnd()}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
