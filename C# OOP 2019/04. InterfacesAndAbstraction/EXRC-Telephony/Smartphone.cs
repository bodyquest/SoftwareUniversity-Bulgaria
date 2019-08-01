namespace EXRC_Telephony
{
    using System;
    using System.Linq;

    using EXRC_Telephony.Exceptions;

    public class Smartphone : ICallable, IBrowsable
    {
        public Smartphone()
        {

        }

        public string Browse(string url)
        {
            if (url.Any(c => Char.IsDigit(c)))
            {
                throw new InvalidUrlException();
            }

            return $"Browsing: {url}!";
        }

        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(c => Char.IsDigit(c)))
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Calling... {phoneNumber}";
        }
    }
}
