namespace CommandPattern.Core.Commands
{
    using System;
    using System.IO;
    using System.Linq;

    using CommandPattern.Core.Contracts;

    public class CreateFileCommand : ICommand
    {
        
        public string Execute(string[] args)
        {
            string fileName = args[0];
            string content = "";

            if (args.Length > 1)
            {
                string[] arrayContent = args.Skip(1).ToArray();
                content += String.Join(" ", arrayContent);
            }

            File.WriteAllText(CurrentPath + fileName, content);

            return $"File {fileName} created successfully";
        }

        public string CurrentPath =>
        Directory.GetCurrentDirectory();
    }
}
