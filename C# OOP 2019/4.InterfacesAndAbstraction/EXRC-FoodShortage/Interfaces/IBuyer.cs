namespace EXRC_FoodShortage.Interfaces
{
    public interface IBuyer : IIdentifiable
    {
        int Food { get; }

        void BuyFood();
    }
}
