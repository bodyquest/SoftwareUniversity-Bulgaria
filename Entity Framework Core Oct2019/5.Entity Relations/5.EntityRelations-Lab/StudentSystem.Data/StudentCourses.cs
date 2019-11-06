using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem.Data
{
    public class StudentCourses
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }
    }
}
