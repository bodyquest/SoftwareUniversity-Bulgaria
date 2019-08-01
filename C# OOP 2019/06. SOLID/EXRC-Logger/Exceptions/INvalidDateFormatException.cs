namespace EXRC_Logger.Exceptions
{
    using System;

    public class INvalidDateFormatException : Exception
    {
        private const string EXC_MESSAGE = "Invalid DateTime Fomrat!";

        public INvalidDateFormatException()
            : base(EXC_MESSAGE)
        {
        }

        public INvalidDateFormatException(string message)
            : base(message)
        {
        }
    }
}
