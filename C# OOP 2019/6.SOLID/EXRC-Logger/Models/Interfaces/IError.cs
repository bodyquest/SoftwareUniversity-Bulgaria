namespace EXRC_Logger.Models.Interfaces
{
    using System;

    using EXRC_Logger.Models.Enumerations;

    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        Level Level { get; }
    }
}
