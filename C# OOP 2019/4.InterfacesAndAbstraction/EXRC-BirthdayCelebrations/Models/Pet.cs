using EXRC_BirthdayCelebrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXRC_BirthdayCelebrations.Models
{
    public class Pet : IBirthable
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public string Birthdate { get; private set; }
    }
}
