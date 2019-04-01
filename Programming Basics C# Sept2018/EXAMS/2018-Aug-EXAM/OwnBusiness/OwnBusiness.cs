using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnBusiness
{
    class OwnBusiness
    {
        static void Main(string[] args)
        {
            int wide = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int high = int.Parse(Console.ReadLine());

            int volume = wide * length * high;
            int sum = 0;
            int computers = 0;

            do
            {
                var input = (Console.ReadLine());
                if (Int32.TryParse(input, out computers))
                {
                    sum += computers;
                }
                else if (input == "Done")
                {
                    Console.WriteLine((volume - sum) + " Cubic meters left.");
                    break;
                }
                if (sum > volume)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(volume - sum)} Cubic meters more.");
                    break;
                }
            }
            while (sum <= volume);

            //string strNum1, strNum2;
            //int num1, num2;
            //int i = 0;
            //int sum = 0;

            //Console.WriteLine("Please enter a integer between 1 and 100"); // asks for user input
            //strNum1 = Console.ReadLine();
            //num1 = int.Parse(strNum1);

            //do //repeat asking for user input
            //{
            //    Console.WriteLine("Please enter another integer between 1 and 100"); // asks for user input
            //    strNum2 = Console.ReadLine();
            //    num2 = int.Parse(strNum2); //input is stored as num2
            //    sum = num2; //store num2 in sum
            //    i++;
            //    if (num2 >= 100) // if num2 int is greater than 100
            //    {
            //        sum = (num1 + num2 + sum); // do calculation
            //        Console.WriteLine("No of integers entered is {0} {1}", i, sum); //output calculation 
            //    }
            //}
            //while (i < 100);



            //string line = Console.ReadLine(); // Get string from user
            //if (line == "exit") // Check string
        }
    }
}
