namespace P03_FootballBetting.Data.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public GenericName Name { get; set; }

        public decimal Balance { get; set; }
    }
}
