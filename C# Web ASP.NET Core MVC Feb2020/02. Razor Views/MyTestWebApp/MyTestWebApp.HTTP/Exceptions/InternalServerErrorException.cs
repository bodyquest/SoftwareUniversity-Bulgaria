namespace MyTestWebApp.HTTP.Exceptions
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class InternalServerErrorException : Exception
    {
        private const string IntenralServerErrorMessage = "The Server has encountered an error.";

        public InternalServerErrorException() : this(IntenralServerErrorMessage)
        {
        }

        public InternalServerErrorException(string message) : base(message)
        {
        }
    }
}
