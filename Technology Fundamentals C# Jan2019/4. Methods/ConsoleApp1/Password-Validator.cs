using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isBetweenSixAndTenChars = CheckStringLength(password);
            bool isOnlyLetterOrDigits = CheckStringChars(password);
            bool haveAtLeastTwoDigits = CheckDigitCount(password);

            if (!isBetweenSixAndTenChars)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!isOnlyLetterOrDigits)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!haveAtLeastTwoDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (isOnlyLetterOrDigits && isOnlyLetterOrDigits && haveAtLeastTwoDigits)
            {
                Console.WriteLine("Password is valid");
            }

        }

        private static bool CheckStringLength(string password)
        {
            if (password.Length >= 6 && password.Length <=10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckStringChars(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if (!char.IsLetterOrDigit(password[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool CheckDigitCount(string password)
        {
            int count = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    count++;
                }
            }

            if (count >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
