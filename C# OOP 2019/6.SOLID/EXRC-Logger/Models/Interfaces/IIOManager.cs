namespace EXRC_Logger.Models.Interfaces
{
    public interface IIOManager
    {
        string CurrentDirectoryPath { get; }

        string CurrentFilePath { get; }

        void EnsureDirectoryAndFileExist();

        string GetCurrentPath();
    }
}
