namespace EXRC_GenericBoxOfInteger
{
    using System;

    public class BoxOfInt<T>
    {
        private T item;

        public BoxOfInt(T item)
        {
            this.item = item;
        }

        public override string ToString()
        {
            return $"{item.GetType()}: {item}";
        }
    }
}
