using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Multivesre_Communication
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            var array = new List<string>();
            StringBuilder arr = new StringBuilder();
            for (int i = 0; i < text.Length-2; i+=3)
            {
                arr.Append(text[i]);
                arr.Append(text[i+1]);
                arr.Append(text[i+2]);
                array.Add(arr.ToString());
                arr.Clear();
            }
            
            List<string> toConvert = new List<string>();
            for (int i = 0; i < array.Count; i++)
            {
                switch (array[i])
                {
                    case "CHU": toConvert.Add("0"); break;
                    case "TEL": toConvert.Add("1"); break;
                    case "OFT": toConvert.Add("2"); break;
                    case "IVA": toConvert.Add("3"); break;
                    case "EMY": toConvert.Add("4"); break;
                    case "VNB": toConvert.Add("5"); break;
                    case "POQ": toConvert.Add("6"); break;
                    case "ERI": toConvert.Add("7"); break;
                    case "CAD": toConvert.Add("8"); break;
                    case "K-A": toConvert.Add("9"); break;
                    case "IIA": toConvert.Add("A"); break;
                    case "YLO": toConvert.Add("B"); break;
                    case "PLA": toConvert.Add("C"); break;
                    default:
                        break;
                }
            }

            int result = 0;
            int sum = 0;
            int base13 = 1;
            List<int> triDec = new List<int>();

            for (int i = toConvert.Count - 1; i >= 0; i--)
            {
                switch (toConvert[i])
                {
                    case "0": triDec.Add(0); break;
                    case "1": triDec.Add(1); break;
                    case "2": triDec.Add(2); break;
                    case "3": triDec.Add(3); break;
                    case "4": triDec.Add(4); break;
                    case "5": triDec.Add(5); break;
                    case "6": triDec.Add(6); break;
                    case "7": triDec.Add(7); break;
                    case "8": triDec.Add(8); break;
                    case "9": triDec.Add(9); break;
                    case "A": triDec.Add(10); break;
                    case "B": triDec.Add(11); break;
                    case "C": triDec.Add(12); break;
                    default:
                        break;
                }
            }

            for (int i = 0; i < triDec.Count; i++)
            {
                result = triDec[i] * base13;
                sum += result;
                base13 *= 13;
            }
            Console.WriteLine(sum);
        }
    }
}
