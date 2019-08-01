using EXRC_Logger.Models.Enumerations;
using EXRC_Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXRC_Logger.Models.Errors
{
    class Error : IError
    {
        //optimal argument for the ctor if there is no argument for Level
        public Error(DateTime dateTime, string message, Level level = Level.INFO)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.Level = level;
        }

        public DateTime DateTime { get; }

        public string Message { get; }

        public Level Level { get; }
    }
}
