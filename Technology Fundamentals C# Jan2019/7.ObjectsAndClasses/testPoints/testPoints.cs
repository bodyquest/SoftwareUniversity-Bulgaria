using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testPoints
{
    class testPoints
    {
        private static Random rnd = new Random();

        static void Main()
        {
            var modalities = new string[]
            {
                "G",
                "W",
                "M"
            };
            List<string> WODScheme = GetWODScheme(modalities, rnd);
            List<string> wodExercises = new List<string>();
           // GetExercisesforWOD(WODScheme);
            for (int i = 0; i < WODScheme.Count; i++)
            {
                if (WODScheme[i] == "G")
                {
                    wodExercises.Add(GetGymnasticExercise());
                }
                else if (WODScheme[i] == "W")
                {
                    wodExercises.Add(GetWeightExercise());
                }
                else if (WODScheme[i] == "M")
                {
                    wodExercises.Add(GetMonoExercise());
                }

            }

            Console.WriteLine(string.Join(" ", WODScheme));
            Console.WriteLine(string.Join("\r\n", wodExercises));

        }
        //private static void GetExercisesforWOD(List<string> WODScheme)
        //{
        //    GetExercisesforWOD(WODScheme);
        //}

        private static List<string> GetWODScheme(string[] modalities, Random rnd)
        {
            List<string> WODScheme = new List<string>();

            int count = rnd.Next(1, 4);
            for (int i = 0; i < count; i++)
            {
                string modality = modalities[rnd.Next(0, modalities.Length)];
                if (count == 1 && modality == "G")
                {
                    int newCount = rnd.Next(2, 4);
                    for (int j = 0; j < newCount; j++)
                    {
                        WODScheme.Add(modality);
                    }
                }
                else
                {
                    WODScheme.Add(modality);
                }
            }

            return WODScheme;
        }

        private static string GetGymnasticExercise()
        {
            string exercise = string.Empty;
            List<string> exercises = new List<string>
            {
                "push ups",
                "pull ups",
                "squats",
                "dips",
                "pistols",
                "T2B",
                "E2K",
                "box jumps",
                "rope climb",
                "C2B",
                "Muscle up",
                "Burpee",
                "Burpee over the Bar",
                "Burpee Box Jump Overs",
                "Lunges",
                "GHD extensions",
                "GHD sit ups",

            };
            return exercise = exercises[rnd.Next(0, exercises.Count)];
        }

        private static string GetWeightExercise()
        {
            string exercise = string.Empty;
            List<string> exercises = new List<string>
            {
                "Wall Balls",
                "Thrusters",
                "Front Squat",
                "Back Squat",
                "OHS",
                "Snatch",
                "Power Snatch",
                "Hang Snatch",
                "Hang Power Snatch",
                "Presses",
                "Push Presses",
                "Push Jerk",
                "Split Jerk",
                "Clean",
                "Hang Clean",
                "Power Clean",
                "Hang Power Clean",
                "KB Swing",
                "KB Snatch",
                "Walking OH KB Lunge",
                "Deadlift",
                "Bench",
                "SDHP",

            };
            return exercise = exercises[rnd.Next(0, exercises.Count)];
        }

        private static string GetMonoExercise()
        {
            string exercise = string.Empty;
            List<string> exercises = new List<string>
            {
                "Air Bike",
                "Row",
                "Jump Rope",
                "Run",
            };
            List<string> runExercises = new List<string>
            {
                "200m",
                "400m",
                "800m",
                "1mile",
                "2miles",
                "5km",
                "10km",
            };
            List<string> rowExercises = new List<string>
            {
                "500m",
                "1000m",
                "2000m",
                "5000m",
                "10km",
            };

            exercise = exercises[rnd.Next(0, exercises.Count)];
            if (exercise =="Run")
            {
                exercise = runExercises[rnd.Next(0, runExercises.Count)];
            }
            else if (exercise == "Row")
            {
                exercise = rowExercises[rnd.Next(0, rowExercises.Count)];
            }
            return exercise;
        }
    }
}
