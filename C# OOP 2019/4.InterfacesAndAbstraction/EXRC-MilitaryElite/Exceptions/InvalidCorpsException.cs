using System;

namespace EXRC_MilitaryElite.Exceptions
{
    public class InvalidCorpsException : Exception
    {
        private const string EXC_MESSAGE = "Invalid corps!";
        public InvalidCorpsException()
            :base(EXC_MESSAGE)
        {

        }

        public InvalidCorpsException(string message) 
            : base(message)
        {
        }
    }
}
