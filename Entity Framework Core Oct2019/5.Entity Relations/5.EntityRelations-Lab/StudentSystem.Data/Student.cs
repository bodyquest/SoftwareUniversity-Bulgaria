namespace StudentSystem.Data
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public PersonName Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<StudentCourses> StudentCourses { get; set; } = new HashSet<StudentCourses>();
    }
}
