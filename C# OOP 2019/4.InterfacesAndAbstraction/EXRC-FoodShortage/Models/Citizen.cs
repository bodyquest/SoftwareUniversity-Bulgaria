namespace EXRC_FoodShortage.Models
{
    using EXRC_FoodShortage.Interfaces;

    public class Citizen : IBuyer
    {
        private int age;
        private string id;
        private string birthdate;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.age = age;
            this.id = id;
            this.birthdate = birthdate;
            this.Food = 0;
        }

        public string Name { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
