namespace EXRC_GenericCountMethodStrings
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
    {
        private List<T> data;

        public Box()
        {
            this.data = new List<T>();
        }

        public List<T> Data => this.data;

        public void AddToList(T item)
        {
            this.data.Add(item);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in this.data)
            {
                result.AppendLine($"{typeof(T)}: {item}");
            }
            return result.ToString().TrimEnd();
        }
    }
}
