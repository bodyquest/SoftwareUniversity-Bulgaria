namespace EXRC_Key_Revolver
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int bulletCost = int.Parse(Console.ReadLine());
            int sizeOfBarrell = int.Parse(Console.ReadLine());
            var bullets = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var locks = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int intelValue = int.Parse(Console.ReadLine());

            Stack<int> revolver = new Stack<int>(bullets);
            Queue lockSequence = new Queue(locks);

            int bulletsShot = 0;

            while (revolver.Count > 0 && lockSequence.Count > 0)
            {
                int currentBullet = revolver.Pop();
                int currentLock = int.Parse(lockSequence.Peek().ToString());
                intelValue -= bulletCost;

                if (currentBullet <= currentLock)
                {
                    
                    lockSequence.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (revolver.Count > 0 && ++bulletsShot == sizeOfBarrell)
                {
                    bulletsShot = 0;
                    Console.WriteLine("Reloading!");
                }
            }

            if (lockSequence.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {lockSequence.Count}");
                return;
            }
            else
            {
                Console.WriteLine($"{revolver.Count} bullets left. Earned ${earned}");
            }
        }
    }
}
