namespace Panda.Services
{
    using System;
    using System.Linq;

    using Panda.Data;
    using Panda.Models;

    public class ReceiptServices : IReceiptServices
    {
        private readonly PandaAppDBContext db;

        public ReceiptServices(PandaAppDBContext context)
        {
            this.db = context;
        }

        public void CreateFormPackage(decimal weight, string packageId, string recipientId)
        {
            var receipt = new Receipt
            {
                PackageId = packageId,
                RecipientId = recipientId,
                Fee = weight * 2.67M,
                IssuedOn = DateTime.UtcNow,
            };

            this.db.Receipts.Add(receipt);
            this.db.SaveChanges();
        }

        public IQueryable<Receipt> GetAll()
        {
            return this.db.Receipts;
        }
    }
}
