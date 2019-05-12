using System;
using System.Collections.Generic;
using System.Text;

namespace EXRC_Family_Tree
{
    public class Result
    {

        public Person MainPerson { get; set; }

        public List<Person> Parents { get; set; }

        public List<Person> Children { get; set; }
    }
}
