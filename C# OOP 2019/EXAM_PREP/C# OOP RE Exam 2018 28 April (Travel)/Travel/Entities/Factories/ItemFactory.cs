namespace Travel.Entities.Factories
{
	using Contracts;
	using Items;
	using Items.Contracts;

	public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{
			switch (type)
			{
				case "CellPhone":
					return new CellPhone();
				case "Colombian":
					return new Colombian();
				case "Jewelery":
					return new Jewelery();
				case "Laptop":
					return new Laptop();
				case "Toothbrush":
					return new Toothbrush();
				case "TravelKit":
					return new TravelKit();
				default:
					return null; //TODO what to put here
			}
		}
	}
}
