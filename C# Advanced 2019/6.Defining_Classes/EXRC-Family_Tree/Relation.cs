using System;
using System.Collections.Generic;
using System.Text;

namespace EXRC_Family_Tree
{
    public class Relation
    {
        public Relation(Person parent, Person child)
        {
            this.Parent = parent;
            this.Child = child;
        }

        public Person Parent { get; set; }

        public Person Child { get; set; }
    }
}
