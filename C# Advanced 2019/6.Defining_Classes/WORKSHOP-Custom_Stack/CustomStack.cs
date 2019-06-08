using System;
using System.Collections.Generic;
using System.Text;

namespace WORKSHOP_Custom_Stack
{
    public class CustomStack
    {
        private int[] innerArr;

        private const int defaultSize = 4;

        public int Count { get; private set; } = 0;

        public CustomStack()
        {
            innerArr = new int[defaultSize];
        }

        public void Push(int element)
        {
            if (innerArr.Length == Count)
            {
                Grow();
            }

            innerArr[Count] = element;
            Count++;
        }

        public int Peek()
        {
            CheckIfEmpty();

            return innerArr[Count - 1];
        }

        public void ForEach(Action<int> action)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                action(innerArr[i]);
            }
        }

        public int Pop()
        {
            CheckIfEmpty();
            Count--;
            int tempElement = innerArr[Count];
            innerArr[Count] = default;

            return tempElement;
        }

        private void Grow()
        {
            int[] tempArr = new int[innerArr.Length * 2];

            innerArr.CopyTo(tempArr, 0);
            innerArr = tempArr;
        }

        private void CheckIfEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is Empty");
            }
        }

    }
}
