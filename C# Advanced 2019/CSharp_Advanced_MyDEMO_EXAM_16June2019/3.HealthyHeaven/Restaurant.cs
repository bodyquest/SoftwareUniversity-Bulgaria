namespace HealthyHeaven
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Restaurant
    {
        private List<Salad> data;

        public Restaurant(string name)
        {
            this.Name = name;
            data = new List<Salad>();
        }

        public string Name { get; set; }

        public void Add(Salad salad)
        {
            data.Add(salad);
        }

        public bool Buy(string name)
        {
            bool result = false;
            foreach(var item in data)
            {
                if (item.Name == name)
                {
                    data.Remove(item);
                    result = true;
                    return result;
                }
            }

            return result;
        }

        public string GetHealthiestSalad()
        {
            Salad healthiest = null;
            int lowestCalories = int.MaxValue;
            foreach (var item in data)
            {
                if (item.GetTotalCalories() < lowestCalories)
                {
                    healthiest = item;
                    lowestCalories = item.GetTotalCalories();
                }
            }

            return healthiest.Name;
        }

        public string GenerateMenu()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{this.Name} have {this.data.Count} salads:");
            foreach (var item in data)
            {
                result.AppendLine(item.ToString());
            }

            return result.ToString();
        }
    }
}
