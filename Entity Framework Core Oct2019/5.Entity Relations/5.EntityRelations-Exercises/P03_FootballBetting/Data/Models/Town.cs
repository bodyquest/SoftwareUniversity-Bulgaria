namespace P03_FootballBetting.Data.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class Town
    {
        public int TownId { get; set; }

        public GenericName Name { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
