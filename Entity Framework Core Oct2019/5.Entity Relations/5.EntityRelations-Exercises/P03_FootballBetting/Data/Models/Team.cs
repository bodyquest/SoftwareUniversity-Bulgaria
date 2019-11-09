namespace P03_FootballBetting.Data.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class Team
    {
        public int TeamId { get; set; }

        public GenericName Name { get; set; }

        public string LogoUrl { get; set; }

        public string Initials { get; set; }

        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; }

        public int SecondaryKitColorId { get; set; }

        public int TownId { get; set; }
        public Town Town { get; set; }



    }
}
