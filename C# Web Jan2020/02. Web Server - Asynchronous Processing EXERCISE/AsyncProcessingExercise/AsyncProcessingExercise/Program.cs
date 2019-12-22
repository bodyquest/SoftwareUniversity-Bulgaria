namespace AsyncProcessingExercise
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            /*
              start
              stop
              time
              reset
              lap
              laps
              exit
             */

            IChronometer chrono = new Chronometer();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "exit")
            {
                switch (input)
                {
                    case "start":
                    {
                        chrono.Start();
                        break;
                    }
                    case "stop":
                    {
                        chrono.Stop();
                        break;
                    }
                    case "lap":
                    {
                        Console.WriteLine(chrono.Lap());
                        break;
                    }
                    case "time":
                    {
                        Console.WriteLine(chrono.GetTime);
                        break;
                    }
                    case "laps":
                    {
                            Console.WriteLine("Laps:" + (chrono.Laps.Count == 0
                                ? "no laps."
                                : "\r\n" + string.Join("\r\n", chrono.Laps.Select((lap, index) => $"{index}. {lap}"))));
                            break;
                    }
                    case "reset":
                    {
                        chrono.Reset();
                        break;
                    }

                    default:
                        break;
                }
            }

        }
    }
}
