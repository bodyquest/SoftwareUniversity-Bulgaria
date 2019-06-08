using System;
using System.Collections.Generic;
using System.Linq;

namespace WORKSHOP_Custom_Stack
{
    public class Program
    {
        static void Main()
        {
            CustomStack st = new CustomStack();

            List<int> list = new List<int>();
            list.Select(BiggerThan5);

            st.Push(5);
            st.Push(4);
            st.Push(3);

            var y = st.Pop();

            st.ForEach(Console.WriteLine);
        }

        public static bool BiggerThan5(int element)
        {
            bool result = false;
            if (element > 5)
            {
                result = true;
            }

            return result;
        }
    }
}
