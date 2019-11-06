namespace StudentSystem.Data
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(80)")]
        public string Name { get; set; }

        [Column(TypeName = "NVARCHAR(MAX)")]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Column(TypeName = ("MONEY"))]
        public decimal Price { get; set; }

        public ICollection<Resource> Resources { get; set; } = new HashSet<Resource>();

        public ICollection<StudentCourses> StudentCourses { get; set; } = new HashSet<StudentCourses>();
    }
}
