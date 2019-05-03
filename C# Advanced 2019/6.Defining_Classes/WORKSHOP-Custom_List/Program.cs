namespace WORKSHOP_Custom_List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Program
    {
        static void Main()
        {
            // void Add(int element)
            // RemoveAt(int index)
            // bool Contains(int element)
            // void Swap(int firstIndex, int secondIndex)
            // ... add more functionality if you can...

            CustomList customList = new CustomList();
            customList.Add(2);
            customList.Add(5);
            customList.Add(6);
            customList.Add(64);
            customList.Add(46);

            var obj = customList.RemoveAt(2);
            Console.WriteLine(customList.Contains(64));
            customList.Swap(1, customList.Capacity); 
        }
    }
}
