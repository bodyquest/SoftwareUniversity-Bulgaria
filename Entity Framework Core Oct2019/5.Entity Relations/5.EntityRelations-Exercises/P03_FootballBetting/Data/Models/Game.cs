namespace P03_FootballBetting.Data.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class Game
    {
        public int GameId { get; set; }

        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        public int HomeTeamGoals { get; set; }
        public int HometeamBetRate { get; set; }


        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }
        public int AwayTeamGoals { get; set; }
        public int AwayteamBetRate { get; set; }

        public DateTime DateTime { get; set; }

        public int DrawBetRate { get; set; }

        public string Result { get; set; }
    }
}
