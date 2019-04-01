using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int count = 0;
            int mainDigit = 0;
            int index = 0;
            int offset = 0;
            StringBuilder message = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (input == 0)
                {
                    message.Append(" ");
                }

                else
                {
                    while (input > 0)
                    {
                        var digit = input % 10;
                        count++;
                        mainDigit = input;
                        input = input / 10;

                    }

                    if (mainDigit == 8 || mainDigit == 9)
                    {
                        offset = (mainDigit - 2) * 3 + 1;
                    }
                    else
                    {
                        offset = (mainDigit - 2) * 3;
                    }
                    index = offset + count - 1;


                    char letter = (char)(97 + index);
                    message.Append(letter);

                    index = 0;
                    count = 0;
                    offset = 0;

                }

            }
            Console.WriteLine(message);
        }
    }
}
