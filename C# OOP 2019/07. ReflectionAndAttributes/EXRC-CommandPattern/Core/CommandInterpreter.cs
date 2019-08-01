namespace CommandPattern
{
    using System;
    using System.Linq;
    using System.Reflection;

    using CommandPattern.Core.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";
        public CommandInterpreter()
        {
        }

        public string Read(string inputLine)
        {
            string[] cmdTokens = inputLine
                .Split(" ", System.StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string commandName = cmdTokens[0] + COMMAND_POSTFIX;

            string[] commandArgs = cmdTokens
                .Skip(1)
                .ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();
            Type[] types = assembly.GetTypes();
            Type typeToCreate = types.FirstOrDefault(t => t.Name == commandName);

            if (typeToCreate == null)
            {
                throw new InvalidOperationException("invalid Command Type!");
            }

            Object instance = Activator.CreateInstance(typeToCreate);

            ICommand command = (ICommand)instance;

            string result = command.Execute(commandArgs);

            return result;
        }
    }
}
