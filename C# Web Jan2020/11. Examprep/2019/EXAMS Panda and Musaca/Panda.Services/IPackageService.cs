namespace Panda.Services
{
    using System.Linq;
    using System.Collections.Generic;

    using Panda.Models;
    using Panda.Models.Enums;

    public interface IPackageService
    {
        ICollection<User> GetAllRecipients();

        ICollection<Package> GetAllDeliveredPackages();

        IQueryable<Package> GetAllByStatus(PackageStatus status, string userId);

        void Create(string description, decimal weight, string shippingAddress, string recipientName);

        void Deliver(string id);
    }
}
