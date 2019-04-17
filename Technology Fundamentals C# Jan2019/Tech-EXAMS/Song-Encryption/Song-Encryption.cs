using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Regex artistRgx = new Regex(@"^[A-Z][a-z ']+$");
            Regex songRgx = new Regex(@"^[A-Z ']+$");

            while (input != "end")
            {
                string[] artistInfo = input.Split(':');
                var array = input.ToCharArray();
                string artist = artistInfo[0];
                string song = artistInfo[1];
                if (artistRgx.IsMatch(artist) && songRgx.IsMatch(song))
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] != ' ' && input[i] != '\'')
                        {
                            if (input[i] == ':')
                            {
                                array[i] = '@';
                            }
                            else
                            {
                                if (char.IsLower(array[i]))
                                {
                                    //works successfully
                                    if (array[i] + artist.Length > 122 )
                                    {
                                        int remaining = artist.Length - (122-array[i]);
                                        array[i] = (char)(remaining + 96);
                                    }
                                    else
                                    {
                                        array[i] = (char)(array[i] + artist.Length);
                                    }
                                }
                                else if (char.IsUpper(array[i]))
                                {
                                    // to do
                                    if (array[i] + artist.Length > 90)
                                    {
                                        int remaining = artist.Length - (90 - array[i]);
                                        array[i] = (char)(remaining + 64);
                                    }
                                    else
                                    {
                                        array[i] = (char)(array[i] + artist.Length);
                                    }

                                }
                                else
                                {
                                    array[i] = (char)(array[i] + artist.Length);
                                }
                            }
                        }
                    }

                    Console.Write("Successful encryption: ");
                    Console.WriteLine(string.Join("", array));
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }
        }
    }
}
