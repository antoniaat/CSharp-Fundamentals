namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using Contracts;
	using Entities.Contracts;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
			var instrumentType = Assembly.GetCallingAssembly().GetTypes()
				.Where(t => typeof(IInstrument).IsAssignableFrom(t))
				.FirstOrDefault(t => t.Name == type);

			var instrument = (IInstrument)Activator.CreateInstance(instrumentType);

			return instrument;
		}
	}
}