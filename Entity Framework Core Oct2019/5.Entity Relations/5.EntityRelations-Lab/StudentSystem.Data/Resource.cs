namespace StudentSystem.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Resource
    {
        public int ResourceId { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR(MAX)")]
        public string Url { get; set; }

        public ResourceType Type { get; set; }

        [ForeignKey(nameof(CourseId))]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}