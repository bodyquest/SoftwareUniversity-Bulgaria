namespace EXRC_Logger.Models
{
    using EXRC_Logger.Models.Interfaces;
    using EXRC_Logger.Models.Enumerations;

    public interface IAppender
    {
        ILayout Layout { get; }

        Level Level { get; }

        void Append(IError error);
    }
}
