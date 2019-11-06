namespace StudentSystem.Data
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PersonName
    {
        private PersonName()
        {
        }

        public PersonName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        [Required]
        [Column("FirstName")]
        public string FirstName { get; private set; }

        [Required]
        [Column("LastName")]
        public string LastName { get; private set; }

        [NotMapped]
        public string FullName  
        { 
            get 
            { 
                return $"{FirstName} {LastName}"; 
            } 
        }
    }
}
