namespace EXRC_Logger.Exceptions
{
    using System;

    class InvalidLevelTypeException : Exception
    {
        private const string EXC_MESSAGE = "Invalid Level Type!";

        public InvalidLevelTypeException()
            : base(EXC_MESSAGE)
        {
        }

        public InvalidLevelTypeException(string message) 
            : base(message)
        {
        }
    }
}
