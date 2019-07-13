namespace EXRC_Telephony.Core
{
    using System;
    using System.Linq;
    using EXRC_Telephony.Exceptions;

    public class Engine
    {
        private Smartphone smartphone;

        public Engine()
        {
            this.smartphone = new Smartphone();
        }

        public void Run()
        {
            var numbers = Console.ReadLine().Split(' ').ToArray();
            var urls = Console.ReadLine().Split(' ').ToArray();

            CallNumbers(numbers);
            BrowseInternet(urls);
        }

        private void CallNumbers(string[] numbers)
        {
            foreach (var number in numbers)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Call(number));
                }
                catch (InvalidPhoneNumberException ipne)
                {
                    Console.WriteLine(ipne.Message);
                }
            }
        }

        private void BrowseInternet(string[] urls)
        {
            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Browse(url));
                }
                catch (InvalidUrlException iue)
                {
                    Console.WriteLine(iue.Message);
                }
            }
        }
    }
}
