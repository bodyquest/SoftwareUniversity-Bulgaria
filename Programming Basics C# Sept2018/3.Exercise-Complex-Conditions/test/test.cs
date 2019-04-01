using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_On_Time_for_the_Exam
{
    class OnTimeForTheExam
    {
        static void Main(string[] args)
        {
            var examHH = int.Parse(Console.ReadLine());
            var examMM = int.Parse(Console.ReadLine());
            var arrivalHH = int.Parse(Console.ReadLine());
            var arrivalMM = int.Parse(Console.ReadLine());
            var onTime = "On time";
            var earlyTime = "Early";
            var lateTime = "Late";
            var beforeT = "before the start";
            var afterT = "after the start";
            var min = "minutes";
            var hour = "hours";

            var examT = (examHH * 60) + examMM;
            var arrivalT = (arrivalHH * 60) + arrivalMM;
            var deltaT = examT - arrivalT;
            var printHH = 0;
            var printMM = 0;

            if (deltaT == 0) // Just On time
            {
                Console.WriteLine(onTime);
            }
            else
            {
                if (deltaT > 0) // (dT>0) If BEFORE start
                {
                    if (deltaT <= 30) // On time MM min before
                    {
                        Console.WriteLine(onTime);
                        Console.WriteLine("{0} {1} {2}", deltaT, min, beforeT);
                    }
                    else // Early Time before
                    {
                        printHH = deltaT / 60;
                        printMM = deltaT % 60;

                        Console.WriteLine(earlyTime);
                        if (printHH == 0)
                        {
                            Console.WriteLine("{0} {1} {2}", printMM, min, beforeT);
                        }
                        else
                        {
                            if (printMM < 10)
                            {
                                Console.WriteLine("{0}:0{1} {2} {3}", printHH, printMM, hour, beforeT);
                            }
                            else
                            {
                                Console.WriteLine("{0}:{1} {2} {3}", printHH, printMM, hour, beforeT);
                            }
                        }

                    }
                }
                else // Late Time after
                {
                    printHH = Math.Abs(deltaT) / 60;
                    printMM = Math.Abs(deltaT) % 60;

                    Console.WriteLine(lateTime);
                    if (printHH == 0)
                    {
                        Console.WriteLine("{0} {1} {2}", printMM, min, afterT);
                    }
                    else
                    {
                        if (printMM < 10)
                        {
                            Console.WriteLine("{0}:0{1} {2} {3}", printHH, printMM, hour, afterT);
                        }
                        else
                        {
                            Console.WriteLine("{0}:{1} {2} {3}", printHH, printMM, hour, afterT);
                        }
                    }
                }
            }
        }
    }
}