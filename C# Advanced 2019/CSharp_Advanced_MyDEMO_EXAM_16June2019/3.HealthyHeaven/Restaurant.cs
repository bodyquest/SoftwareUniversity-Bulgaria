namespace HealthyHeaven
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Restaurant
    {
        private List<Salad> data;

        public Restaurant(string name)
        {
            Name = name;
            data = new List<Salad>();
        }

        public string Name { get; set; }

        public void Add(Salad salad)
        {
            data.Add(salad);
        }

        public bool Buy(string name)
        {
            if (data.FirstOrDefault(s => s.Name == name) != null)
            {
                data.Remove(data.FirstOrDefault(s => s.Name == name));
                return true;
            }
            else
            {
                return false;
            }
        }

        public Salad GetHealthiestSalad()
        {
            int min = data.Min(s => s.GetTotalCalories());

            return data.FirstOrDefault(s => s.GetTotalCalories() == min);
        }

        public string GenerateMenu()
        {
            StringBuilder result = new StringBuilder();
            if (data.Count == 1)
            {
                result.AppendLine($"{this.Name} have {this.data.Count} salad:");
            }
            else
            {
                result.AppendLine($"{Name} have {data.Count} salads:");
            }

            for (int i = 0; i < data.Count; i++)
            {
                if (i == data.Count -1)
                {
                    result.Append(data[i].ToString());
                }
                else
                {
                    result.AppendLine(data[i].ToString());
                }
            }

            return result.ToString();
        }
    }
}
