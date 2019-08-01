namespace EXRC_MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using EXRC_MilitaryElite.Contracts;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<IMission> missions;

        public Commando(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => this.missions;

        public void AddMission(IMission mission)
        {
            if (true)
            {

            }

            this.missions.Add(mission);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString())
                .AppendLine("Missions:");

            foreach (var mis in this.Missions)
            {
                result.AppendLine($"  {mis.ToString()}");
            }

            return result.ToString().TrimEnd(); 
        }
    }
}
