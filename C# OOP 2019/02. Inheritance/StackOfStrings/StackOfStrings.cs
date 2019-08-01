namespace CustomStack
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StackOfStrings<T> : Stack<T>
    {


        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public void PushRange(params T[] data)
        {
            foreach (var item in data)
            {
                this.Push(item);
            }
        }
    }
}
