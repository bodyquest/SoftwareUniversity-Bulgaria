namespace MyTestWebApp.HTTP.Exceptions
{
    using System;

    public class BadRequestException : Exception
    {
        private const string BadRequestExceptionMessage = "The Request was malformed or contains unsupported elements.";

        public BadRequestException() :this(BadRequestExceptionMessage)
        {
        }

        public BadRequestException(string name) : base(name)
        {
        }
    }
}
