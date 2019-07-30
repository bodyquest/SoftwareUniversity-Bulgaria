namespace Travel.Entities.Factories
{
    using System;
    using System.Linq;

    using Contracts;
	using Items.Contracts;
    using System.Reflection;

    public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{
            var itemType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            var itemInstance = (IItem)Activator
                    .CreateInstance(itemType);

            return itemInstance;
        }
	}
}
