using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Topic
    {
        //EF will get all comments of the topic and will put them in the list.
        public Topic()
        {
            this.Comments = new List<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Display (Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Last Updated Date")]
        public DateTime LastUpdatedDate { get; set; }

        //this is how to tell EF that this model is connected to another model. Each topic will be related to its author

        public string AuthorId { get; set; }
        public virtual ApplicationUser Author{ get; set; }

        //we want each TOPIC to show ALL COMMENTS
        public List<Comment> Comments { get; set; }
        //make constructor at the beginning of this class to fill this list

        //this is the number of comments that we will get
        [NotMapped]
        [Display(Name = "Number Comments")]
        public int NumberComments => this.Comments.Count;
    }
}
