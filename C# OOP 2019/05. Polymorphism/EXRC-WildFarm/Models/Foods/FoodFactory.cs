namespace EXRC_WildFarm.Models.Foods
{
    public static class FoodFactory
    {
        public static Food Create(params string[] foodArgs)
        {
            string type = foodArgs[0];
            int qty = int.Parse(foodArgs[1]);

            if (type == nameof(Vegetable))
            {
                return new Vegetable(qty);
            }
            else if (type == nameof(Fruit))
            {
                return new Fruit(qty);
            }
            else if (type == nameof(Meat))
            {
                return new Meat(qty);
            }
            else if (type == nameof(Seeds))
            {
                return new Seeds(qty);
            }

            return null;
        }
    }
}
