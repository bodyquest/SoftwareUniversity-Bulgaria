using System;
using System.Collections.Generic;

namespace Demo.Data
{
    public partial class Addresses
    {
        public Addresses()
        {
            Employees = new HashSet<Employees>();
        }

        public int AddressId { get; set; }
        public string AddressText { get; set; }
        public int? TownId { get; set; }

        public Towns Town { get; set; }
        public ICollection<Employees> Employees { get; set; }
    }
}
