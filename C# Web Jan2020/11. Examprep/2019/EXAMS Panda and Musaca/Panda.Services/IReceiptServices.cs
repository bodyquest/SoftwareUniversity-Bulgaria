namespace Panda.Services
{
    using System.Linq;

    using Panda.Models;

    public interface IReceiptServices
    {
        void CreateFormPackage(decimal weight, string packageId, string recipientId);

        IQueryable<Receipt> GetAll();
    }
}
