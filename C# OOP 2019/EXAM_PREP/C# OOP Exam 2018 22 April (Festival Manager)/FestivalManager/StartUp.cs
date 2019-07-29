namespace FestivalManager
{
	using Core;
	using Core.IO;
	using Entities;
	using Core.Contracts;
	using Core.Controllers;
	using Core.IO.Contracts;
	using Entities.Contracts;
	using Core.Controllers.Contracts;
    using FestivalManager.Entities.Factories;

    public static class StartUp
	{
		public static void Main(string[] args)
		{
			IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IStage stage = new Stage();
            IFestivalController festivalController = new FestivalController(
                stage, 
                new SetFactory(),
                new InstrumentFactory());
            ISetController setController = new SetController(stage);

			IEngine engine = new Engine(reader, writer, festivalController, setController);

			engine.Run();
		}
	}
}