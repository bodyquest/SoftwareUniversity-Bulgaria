using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Last Updated Date")]
        public DateTime LastUpdatedDate { get; set; }

        //we make the RELATION between the AUTHOR and COMMENT
        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }

        //second RELATION of COMMENT AND TOPIC - one comment belongs to one topic
        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }

        
        
    }
}
