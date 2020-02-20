namespace KENOV_Essentials.Services
{
    using System.Collections.Generic;

    public interface ICatsService
    {
        IEnumerable<string> Cats { get; set; }
    }
}
