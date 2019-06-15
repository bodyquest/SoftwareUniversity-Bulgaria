namespace EXRC_GenericBoxOfString
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Box<T>
    {
        private T item;

        public Box(T item)
        {
            this.item = item;
        }

        public override string ToString()
        {
            return $"{item.GetType()}: {item}"; 
        }
    }
}
