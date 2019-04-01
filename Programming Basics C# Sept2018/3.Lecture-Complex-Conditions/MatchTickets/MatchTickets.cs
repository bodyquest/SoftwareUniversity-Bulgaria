using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchTickets
{
    class MatchTickets
    {
        static void Main(string[] args)
        {
            //            Когато пуснали билетите за Евро 2016, група запалянковци решили да си закупят. Билетите имат две категории с различни цени:

            //•	VIP – 499.99 лева.
            //•	Normal – 249.99 лева.
            //Запалянковците имат определен бюджет, a броят на хората в групата определя какъв процент от бюджета трябва да се задели за транспорт:
            //•	От 1 до 4 – 75 % от бюджета.
            //•	От 5 до 9 – 60 % от бюджета.
            //•	От 10 до 24 – 50 % от бюджета.
            //•	От 25 до 49 – 40 % от бюджета.
            //•	50 или повече – 25 % от бюджета.
            // Напишете програма, която да пресмята дали с останалите пари от бюджета могат да си купят билети за избраната категория. И колко пари ще им останат или ще са им нужни.
            //Вход
            //Програмата чете точно 3 реда , въведени от потребителя:
            //•	На първия ред е бюджетът – реално число в интервала[1 000.00... 1 000 000.00]
            //•	На втория ред е категорията – текст с възможности "VIP" или "Normal"
            //•	На третия ред е броят на хората в групата – цяло число в интервала[1... 200]
            //Изход
            //Да се отпечата на конзолата един ред:
            //•	Ако бюджетът е достатъчен:
            //o   "Yes! You have {N} leva left."– N са останалите пари на групата
            //•	Ако бюджетът НЕ Е достатъчен:
            //            o   "Not enough money! You need {М} leva." – където М е сумата, която не достига
            //Сумите трябва да са форматирани с точност до два знака след десетичната запетая.

            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int people = int.Parse(Console.ReadLine());
            double VIP = 499.99;
            double Normal = 249.99;

            double moneyLeft = 1;
            double ticketMoney = 1;

            

            if (category =="VIP")
            {
                ticketMoney = VIP * people;
                if (people >= 1 && people <= 4)
                {
                    moneyLeft = 0.25 * budget;
                }
                else if (people >= 5 && people <= 9)
                {
                    moneyLeft = 0.4 * budget;
                }
                else if (people >= 10 && people <= 24)
                {
                    moneyLeft = 0.5 * budget;
                }
                else if (people >= 25 && people <= 49)
                {
                    moneyLeft = 0.6 * budget;
                }
                else if (people >= 50)
                {
                    moneyLeft = 0.75 * budget;
                }
                if (moneyLeft >= ticketMoney)
                {

                    Console.WriteLine($"Yes! You have {moneyLeft - ticketMoney:f2} leva left.");
                }
                else if (moneyLeft < ticketMoney)
                {
                    Console.WriteLine($"Not enough money! You need {ticketMoney- moneyLeft:f2} leva.");
                }
            }
            else if (category == "Normal")
            {
                ticketMoney = Normal * people;
                if (people >= 1 && people <= 4)
                {
                    moneyLeft = 0.25 * budget;
                }
                else if (people >= 5 && people <= 9)
                {
                    moneyLeft = 0.4 * budget;
                }
                else if (people >= 10 && people <= 24)
                {
                    moneyLeft = 0.5 * budget;
                }
                else if (people >= 25 && people <= 49)
                {
                    moneyLeft = 0.6 * budget;
                }
                else if (people >= 50)
                {
                    moneyLeft = 0.75 * budget;
                }
                if (moneyLeft >= ticketMoney)
                {
                    Console.WriteLine($"Yes! You have {moneyLeft - ticketMoney:f2} leva left.");
                }
                else if (moneyLeft < ticketMoney)
                {
                    Console.WriteLine($"Not enough money! You need {ticketMoney - moneyLeft:f2} leva.");
                }
            }

        }
    }
}
