namespace EXRC_WildFarm.Models.Foods
{
    public abstract class Food
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; set; }
    }
}
