using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity
{
    class Charity
    {
        static void Main(string[] args)
        {

            // В сладкарница се провежда благотворителна кампания за събиране на средства, в която могат да се включат сладкари от цялата страна.
            // Първоначално прочитаме от конзолата броя на дните, в които тече кампанията и броя на сладкарите, които ще се включат.
            // След това на отделни редове получаваме количеството на тортите, гофретите и палачинките, които ще бъдат приготвени от един сладкар за един ден.
            //Трябва да се има предвид следния ценоразпис:
            //•	Торта - 45 лв.
            //•	Гофрета - 5.80 лв.
            //•	Палачинка – 3.20 лв.
            //1 / 8 от крайната сума ще бъде използвана за покриване на разходите за продуктите по време на кампанията.

            //>>>>>>>>>Да се напише програма, която изчислява сумата, която е събрана в края на кампанията. <<<<<<<<<<
            //Вход
            //От конзолата се четат 5 реда:
            //            1.Броят на дните, в които тече кампанията – цяло число в интервала[0 … 365]
            //2.Броят на сладкарите – цяло число в интервала[0 … 1000]
            //3.Броят на тортите – цяло число в интервала[0… 2000]
            //4.Броят на гофретите – цяло число в интервала[0 … 2000]
            //5.Броят на палачинките – цяло число в интервала[0 … 2000]

            int daysCount = int.Parse(Console.ReadLine());
            int bakersCount = int.Parse(Console.ReadLine());
            int cakesCount = int.Parse(Console.ReadLine());
            int wafflesCount = int.Parse(Console.ReadLine());
            int pancakesCount = int.Parse(Console.ReadLine());

            double cakePrice = 45;
            double cakeSum = cakePrice * cakesCount;

            double wafflePrice = 5.80;
            double waffleSum = wafflePrice * wafflesCount;

            double pancakePrice = 3.20;
            double pancakeSum = pancakePrice * pancakesCount;

            double allMoney = (cakeSum + waffleSum + pancakeSum) * bakersCount;
            double allCampaignMoney = allMoney * daysCount;
            double expenses = allCampaignMoney / 8;
            double charityMoney = allCampaignMoney - expenses;

            Console.WriteLine($"{charityMoney:F2}");

        }
    }
}
