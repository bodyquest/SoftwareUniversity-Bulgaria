namespace DungeonsAndCodeWizards.Models.Bags
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using DungeonsAndCodeWizards.Models.Items;

    public abstract class Bag
    {
        private int capacity;

        private const int DEFAULT_CAPACITY = 100;

        private List<Item> items;

        protected Bag()
        {
            this.Capacity = DEFAULT_CAPACITY;
            this.items = new List<Item>();
        }

        protected Bag(int capacity)
            : this()
        {
            this.Capacity = capacity;
        }

        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        public int Load => this.Items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items
        {
            get
            {
                return this.items.AsReadOnly();
            }
        }

        public void Additem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            var item = this.Items.FirstOrDefault(x => x.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            items.Remove(item);

            return item;
        }
    }
}
