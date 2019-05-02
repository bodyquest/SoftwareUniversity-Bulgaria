using System;
using System.Collections.Generic;

namespace WORKSHOP_Create_Linked_List
{
    public class CoolStack
    {
        private object[] values;
        private int count;

        public CoolStack()
            : this(16)
        {
        }

        public CoolStack(int initialCapacity)
        {
            this.count = 0;
            this.values = new object[initialCapacity];
        }
        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Push (object value)
        {
            if (this.count == this.values.Length)
            {
                var nextValues = new object[this.values.Length * 2];
                for (int i = 0; i < this.values.Length; i++)
                {
                    nextValues[i] = this.values[i];
                }

                this.values = nextValues;
            }

            this.values[this.count] =value;
            this.count++;
        }

        public object Pop()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Cool stack is empty.");
            }

            var lastIndex = this.count - 1;
            var last = this.values[lastIndex];
            this.count--;
            return last;
        }

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < this.count; i++)
            {
                action(this.values[i]);
            }
        }
    }
}
