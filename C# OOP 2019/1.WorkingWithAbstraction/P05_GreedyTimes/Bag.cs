namespace P05_GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bag
    {
        private long capacity;

        private List<Item> items;

        public Bag(long capacity)
        {
            this.capacity = capacity;
            items = new List<Item>();
        }

        public long GoldValue
        {
            get
            {
                return items.Where(i => i is Gold).Sum(i => i.Amount);
            }
        }

        public long GemsValue
        {
            get
            {
                return items.Where(i => i is Gem).Sum(i => i.Amount);
            }
        }

        public long CashValue
        {
            get
            {
                return items.Where(i => i is Cash).Sum(i => i.Amount);
            }
        }

        public void Add(Item item)
        {
            long currentAggregation = this.GoldValue + this.GemsValue + this.CashValue;

            if (item.Type == "Gold" 
                && item.Amount + this.GoldValue >= this.GemsValue
                && item.Amount + currentAggregation <= this.capacity)
            {
                this.items.Add(item);
            }
            else if (item.Type == "Gem" 
                && item.Amount + this.GemsValue >= this.CashValue
                && item.Amount + currentAggregation <= this.capacity)
            {
                this.items.Add(item);
            }
            else if (item.Type == "Cash"
                && item.Amount + currentAggregation <= this.capacity)
            {
                this.items.Add(item);
            }
        }

        public string PrintContents()
        {
            StringBuilder result = new StringBuilder();

            foreach (var item in items)
            {
                // TO DO

            }

            return result.ToString().TrimEnd();
        }
    }
}
