 namespace EXRC_GenericTuple
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tuple<T, K>
    {
        private T item1;
        private K item2;

        public Tuple(T item1, K item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public override string ToString()
        {
            return $"{this.item1} -> {this.item2}";
        }
    }
}
