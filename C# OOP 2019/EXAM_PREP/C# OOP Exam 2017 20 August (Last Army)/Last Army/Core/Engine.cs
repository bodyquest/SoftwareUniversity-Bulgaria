using System;

public class Engine
{
    private const string enoughPullBack = "Enough! Pull back!";
    private IReader reader;
    private IWriter writer;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        var input = reader.ReadLine(); 
        var gameController = new GameController(writer);

        while (!input.Equals(enoughPullBack))
        {
            try
            {
                gameController.GiveInputToGameController(input);
            }
            catch (ArgumentException arg)
            {
                writer.AppendLine(arg.Message);
            }
             
            input = reader.ReadLine();
        }

        gameController.RequestResult();
        writer.WriteAll();
    }
}

