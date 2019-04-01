using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Boxes
{
    class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }

    class Box
    {
        public int SerialNumber { get; set; }
        public string Item { get; set; }
        public string ItemQuantity { get; set; }
        public decimal PriceForBox { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine().Split(' ').ToArray();
            while (data[0] != "end")
            {


                data = Console.ReadLine().Split(' ').ToArray();
            }
        }
    }
}
