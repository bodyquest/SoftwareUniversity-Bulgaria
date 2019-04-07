using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TeisterMask.Models
{
    //FIRST WE MAKE OUR ENTITIES FOR THE PROJECT
    public class Task
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
