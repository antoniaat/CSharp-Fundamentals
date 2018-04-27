namespace FestivalManager.Core
{
	using System;
	using System.Linq;
	using System.Reflection;
	using Contracts;
	using Controllers.Contracts;
	using IO.Contracts;

	public class Engine : IEngine
	{
		private readonly IReader reader;
		private readonly IWriter writer;

		private readonly IFestivalController festivalController;
		private readonly ISetController setController;

		public Engine(IReader reader, IWriter writer, IFestivalController festivalController, ISetController setController)
		{
			this.reader = reader;
			this.writer = writer;
			this.festivalController = festivalController;
			this.setController = setController;
		}

		public void Run()
		{
			while (true)
			{
				var input = reader.ReadLine();

				if (input == "END")
				{
					break;
				}

				try
				{
					var result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (InvalidOperationException ex)
				{
					this.writer.WriteLine("ERROR: " + ex.Message);
				}
			}

			var report = this.festivalController.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(report);
		}

		public string ProcessCommand(string input)
		{
			var tokens = input.Split(' ');

			var command = tokens.First();
			var args = tokens.Skip(1).ToArray();

			if (command == "LetsRock")
			{
				var setResult = this.setController.PerformSets();
				return setResult;
			}

			var commandMethod = this.festivalController.GetType()
				.GetMethods()
				.FirstOrDefault(mi => mi.Name == command);

			string output;

			try
			{
				output = (string)commandMethod.Invoke(this.festivalController, new object[] { args });
			}
			catch (TargetInvocationException ex)
			{
				throw ex.InnerException;
			}

			return output;
		}
	}
}