namespace EXRC_Logger.Factories
{
    using System;
    using System.Globalization;

    using EXRC_Logger.Exceptions;
    using EXRC_Logger.Models.Errors;
    using EXRC_Logger.Models.Interfaces;
    using EXRC_Logger.Models.Enumerations;

    public class ErrorFactory
    {
        private const string dateFormat = "M/dd/yyyy h:mm:ss tt";

        public IError GetError(string dateString, string levelString, string message)
        {
            Level level;
            bool hasParsed = Enum.TryParse<Level>(levelString, out level);

            if (!hasParsed)
            {
                throw new InvalidLevelTypeException();
            }

            DateTime dateTime;

            try
            {
                dateTime = DateTime.ParseExact(dateString, dateFormat, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw new INvalidDateFormatException();
            }

            return new Error(dateTime, message, level);
        }
    }
}
