namespace EXRC_Logger.Models.Interfaces
{
    public interface IFile
    {
        string Path { get; }

        ulong Size { get; }

        string Write(ILayout layout, IError error);
    }
}
