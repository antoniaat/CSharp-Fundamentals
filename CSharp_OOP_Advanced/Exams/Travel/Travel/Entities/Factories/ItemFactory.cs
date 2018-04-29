namespace Travel.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using Items.Contracts;

    public class ItemFactory : IItemFactory
    {
        public IItem CreateItem(string type)
        {
            var allTypes = Assembly.GetCallingAssembly().GetTypes();

            var setType = allTypes
                .Where(t => typeof(IItem).IsAssignableFrom(t))
                .FirstOrDefault(t => t.Name == type);

            var item = (IItem)Activator.CreateInstance(setType);

            return item;
        }
    }
}