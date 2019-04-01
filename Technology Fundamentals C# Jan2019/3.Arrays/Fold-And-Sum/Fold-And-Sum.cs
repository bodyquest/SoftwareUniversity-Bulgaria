using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fold_And_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int k = arr.Length / 4;

            var arrTop = arr.Take(k).Reverse().Concat(arr.Skip(3 * k).Reverse()).ToArray();
            var bottom = arr.Skip(k).Take(3 * k - k).ToArray();
            var result = arrTop.Zip(bottom, (x, y) => x + y).ToArray();

            Console.WriteLine(string.Join(" ", result));

        }
    }
}
