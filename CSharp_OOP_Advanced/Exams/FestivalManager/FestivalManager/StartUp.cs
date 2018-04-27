namespace FestivalManager
{
	using System.IO;
	using System.Linq;
	using Core;
	using Core.Contracts;
	using Core.Controllers;
	using Core.Controllers.Contracts;
	using Core.IO;
	using Core.IO.Contracts;
	using Entities;
	using Entities.Contracts;

	public static class StartUp
	{
		public static void Main(string[] args)
		{
			IReader reader;

			if (args.Length == 1)
			{
				var testPath = args.First();
				reader = new Core.IO.StringReader(File.ReadAllText(testPath));
			}
			else
			{
				reader = new ConsoleReader();
			}

			IWriter writer = new ConsoleWriter();

			IStage stage = new Stage();
			IFestivalController festivalController = new FestivalController(stage);
			ISetController setController = new SetController(stage);

			IEngine engine = new Engine(reader, writer, festivalController, setController);

			engine.Run();
		}
	}
}