using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Party_Invitation
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputName = String.Empty;
            double countValid = 0;
            double countInvalid = 0;
            double countAll = 0;

            while (inputName != "Statistic")
            {
                inputName = Console.ReadLine();
                if (inputName == "Statistic")
                {
                    break;
                }
                countAll++;
                if (inputName.All(char.IsLetter))
                {
                    countValid++;
                    if (inputName != char.ToUpper(inputName[0]) + inputName.Substring(1).ToLower())
                    {
                        inputName = char.ToUpper(inputName[0]) + inputName.Substring(1).ToLower();
                        Console.WriteLine(inputName);
                    }
                    else
                    {
                        Console.WriteLine(inputName);
                    }
                    
                }
                else
                {
                    countInvalid++;
                    Console.WriteLine("Invalid name!");
                }
                
            }
            Console.WriteLine($"Valid names are {(countValid/countAll*100):f2}% from {countAll} names.");
            Console.WriteLine($"Invalid names are {(countInvalid / countAll * 100):f2}% from {countAll} names.");


            //String labelName = "heLlO";
            //labelName = char.ToUpper(labelName[0]) + labelName.Substring(1).ToLower();
            //Console.WriteLine(labelName);
        }
    }
}
