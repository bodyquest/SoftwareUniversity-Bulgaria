using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Songs
{
    class Songs
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }

        static void Main(string[] args)
        {
            int songsNumber = int.Parse(Console.ReadLine());
            List<Songs> songs = new List<Songs>();

            for (int i = 0; i < songsNumber; i++)
            {
                var songData = Console.ReadLine().Split('_').ToArray();
                string type = songData[0];
                string name = songData[1];
                string time = songData[2];

                Songs song = new Songs();
                song.TypeList = type;
                song.Name = name;
                song.Time = time;
                songs.Add(song);
            }

            string typeList = Console.ReadLine();
            if (typeList == "all")
            {
                foreach (Songs song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Songs song in songs)
                {
                    if (song.TypeList == typeList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }
}
