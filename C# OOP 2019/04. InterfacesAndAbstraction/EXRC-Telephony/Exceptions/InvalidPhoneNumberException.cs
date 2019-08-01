namespace EXRC_Telephony.Exceptions
{
    using System;

    public class InvalidPhoneNumberException : Exception
    {
        private const string EXC_MESSAGE = "Invalid number!";

        public InvalidPhoneNumberException()
            : base(EXC_MESSAGE)
        {
        }

        public InvalidPhoneNumberException(string message)
            : base(message)
        {
        }
    }
}
