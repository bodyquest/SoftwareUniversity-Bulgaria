namespace Hit_List
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            int targetIndex = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            var HitList = new HitList();

            while (input != "end transmissions")
            {
                // TO DO - Fix splitting problem
                var array = input.Split(';').ToArray();
                string[] nameInfo = array[0].Split('=').ToArray();
                string name = nameInfo[0];
                Person person = new Person(name);

                string[] firstKvp = nameInfo[1].Split(':').ToArray();
                string fistKey = firstKvp[0];
                string firstValue = firstKvp[1];

                person.AddPersonInfo(fistKey, firstValue);
                if (array.Length > 1)
                {
                    for (int i = 1; i < array.Length; i++)
                    {
                        string[] info = array[i].Split(':').ToArray();
                        person.AddPersonInfo(info[0], info[1]);
                    }
                }

                HitList.AddPerson(person);
                input = Console.ReadLine();
            }

            var lastInput = Console.ReadLine().Split(' ').ToArray();
            string nameToKill = lastInput[1];
            Console.WriteLine(HitList.KillName(nameToKill));

            if (HitList.People[nameToKill].InfoIndex >= targetIndex )
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetIndex - HitList.People[nameToKill].InfoIndex} more info.");
            }
        }
    }
}
