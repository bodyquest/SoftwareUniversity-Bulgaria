using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorrentPirate
{
    class TorrentPirate
    {
        static void Main(string[] args)
        {
            double download = double.Parse(Console.ReadLine());
            double costCinema = double.Parse(Console.ReadLine());
            double wifeSpending = double.Parse(Console.ReadLine());

            double downloadTime = download / 2 / 60 / 60;
            double priceToDownload = downloadTime * wifeSpending;
            double moviesDownloaded = download / 1500;
            double cinemaTotalPrice = moviesDownloaded * costCinema;

            if (priceToDownload > cinemaTotalPrice)
            {
                Console.WriteLine($"cinema -> {cinemaTotalPrice:f2}lv");
            }
            else
            {
                Console.WriteLine($"mall -> {priceToDownload:f2}lv");
            }

        }
    }
}
