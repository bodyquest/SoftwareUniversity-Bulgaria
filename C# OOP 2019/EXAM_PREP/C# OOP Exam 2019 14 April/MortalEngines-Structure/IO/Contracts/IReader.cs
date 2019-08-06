namespace MortalEngines.IO.Contracts
{
    using MortalEngines.Core.Contracts;
    using System.Windows.Input;
    using System.Collections.Generic;

    public interface IReader
    {
        IList<ICommand> ReadCommands();
    }
}