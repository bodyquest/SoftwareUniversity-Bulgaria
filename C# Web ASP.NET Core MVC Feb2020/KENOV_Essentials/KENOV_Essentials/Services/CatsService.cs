namespace KENOV_Essentials.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CatsService : ICatsService
    {
        public CatsService()
        {
            this.Cats = new[] { "Dari", "Rosi" };
        }

        public IEnumerable<string> Cats { get; set; }
            
    }
}
