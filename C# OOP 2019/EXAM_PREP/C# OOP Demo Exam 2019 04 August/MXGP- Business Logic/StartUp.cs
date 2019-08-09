using MXGP.IO;
using MXGP.Core.Contracts;
using MXGP.Core;
using MXGP.Repositories;

public class StartUp
{
    public static void Main()
    {
        var reader = new ConsoleReader();
        var writer = new ConsoleWriter();

        var controller = new ChampionshipController();

        IEngine engine = new Engine(reader, writer, controller);

        engine.Run();
    }
}