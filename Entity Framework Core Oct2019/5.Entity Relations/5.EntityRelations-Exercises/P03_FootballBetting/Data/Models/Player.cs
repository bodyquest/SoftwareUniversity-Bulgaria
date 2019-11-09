namespace P03_FootballBetting.Data.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class Player
    {
        public int PlayerId { get; set; }

        public GenericName Name { get; set; }

        public int SquadNumber { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        public bool IsInjured { get; set; }
    }
}
