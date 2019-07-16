namespace EXRC_FoodShortage.Models
{
    using EXRC_FoodShortage.Interfaces;

    public class Rebel : IBuyer
    {
        private int age;
        private string group;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.age = age;
            this.group = group;
            this.Food = 0;
        }

        public string Name { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
