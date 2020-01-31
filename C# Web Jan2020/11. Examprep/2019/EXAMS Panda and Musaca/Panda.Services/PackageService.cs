namespace Panda.Services
{
    using System.Linq;
    using System.Collections.Generic;

    using Panda.Data;
    using Panda.Models;
    using Panda.Models.Enums;

    public class PackageService : IPackageService
    {
        private readonly PandaAppDBContext db;
        private readonly IReceiptServices receiptServices;

        public PackageService(PandaAppDBContext pandaAppDBContext, IReceiptServices receiptServices)
        {
            this.db = pandaAppDBContext;
            this.receiptServices = receiptServices;
        }

        public void Create(string description, decimal weight, string shippingAddress, string recipientName)
        {
            var userId = this.db.Users
                                .Where(x => x.Username == recipientName)
                                .Select(x => x.Id)
                                .FirstOrDefault();

            if (userId == null)
            {
                return;
            }

            var package = new Package
            {
                Description = description,
                Weight = weight,
                Status = PackageStatus.Pending,
                ShippingAddress = shippingAddress,
                RecipientId = userId,
            };

            this.db.Packages.Add(package);
            this.db.SaveChanges();
        }

        public ICollection<Package> GetAllDeliveredPackages()
        {
            return db.Packages.Where(x => x.Status == PackageStatus.Delivered).ToList();
        }

        public IQueryable<Package> GetAllByStatus(PackageStatus status, string userId)
        {
            var packages = this.db.Packages.Where(x => x.Status == status && x.Id == userId);
            return packages;
        }

        public ICollection<User> GetAllRecipients()
        {
            return db.Users.ToList();
        }

        public void Deliver(string id)
        {
            var package = this.db.Packages.FirstOrDefault(x => x.Id == id);
            if (package == null)
            {
                return;
            }

            package.Status = PackageStatus.Delivered;
            this.db.SaveChanges();

            this.receiptServices.CreateFormPackage(package.Weight, package.Id, package.RecipientId);
        }

    }
}
