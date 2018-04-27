using System;

namespace FestivalManager.Entities.Factories
{
	using System.Linq;
	using System.Reflection;
	using Contracts;
	using Entities.Contracts;

	public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
			var allTypes = Assembly.GetCallingAssembly().GetTypes();

			var setType = allTypes
				.Where(t => typeof(ISet).IsAssignableFrom(t))
				.FirstOrDefault(t => t.Name == type);

			var set = (ISet)Activator.CreateInstance(setType, name);

			return set;
		}
	}
}
