namespace HealthyHeaven
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Salad
    {
        private List<Vegetable> products;

        public Salad(string name)
        {
            this.Name = name;
            products = new List<Vegetable>();
        }

        public string Name { get; set; }

        public int GetTotalCalories()
        {
            int calories = 0;
            for (int i = 0; i < products.Count; i++)
            {
                calories += products[i].Calories;
            }

            return calories;
        }

        public int GetProductCount()
        {
            return products.Count;
        }

        public void Add(Vegetable product)
        {
            products.Add(product);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"* Salad {this.Name} is {GetTotalCalories()} calories and have {GetProductCount()} products:");
            for (int i = 0; i < products.Count; i++)
            {
                if (i == products.Count -1)
                {
                    result.Append(products[i].ToString());
                }
                else
                {
                    result.AppendLine(products[i].ToString());
                }
            }

            return result.ToString();
        }
    }
}
