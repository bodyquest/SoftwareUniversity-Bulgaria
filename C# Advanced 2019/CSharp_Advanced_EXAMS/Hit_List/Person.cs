namespace Hit_List
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        private Dictionary<string, string> kvp;

        private int infoIndex;

        public Person()
        {
        }

        public Person(string name)
        {
            Name = name;
            kvp = new Dictionary<string, string>();
            this.Kvp = kvp;
            this.InfoIndex = infoIndex;
        }

        public string Name { get; set; }

        public Dictionary<string, string> Kvp { get; set; }

        public int InfoIndex { get; set; }

        public void AddPersonInfo(string key, string value)
        {
            if (kvp.ContainsKey(key))
            {
                kvp[key] = value;
            }
            else
            {
                kvp.Add(key, value);
            }
        }
    }
}
