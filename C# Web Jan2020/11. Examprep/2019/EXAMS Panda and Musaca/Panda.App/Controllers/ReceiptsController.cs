namespace Panda.App.Controllers
{
    using System.Linq;
    using System.Collections.Generic;

    using Panda.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Result;
    using Panda.App.ViewModels.Receipts;
    using SIS.MvcFramework.Attributes.Security;

    public class ReceiptsController : Controller
    {
        private readonly IReceiptServices receiptsService;

        public ReceiptsController(IReceiptServices receiptsService)
        {
            this.receiptsService = receiptsService;
        }

        [Authorize]
        public IActionResult Index()
        {
            List<ReceiptViewModel> viewModel = this.receiptsService.GetAll().Select(
                x => new ReceiptViewModel
                {
                    Id = x.Id,
                    Fee = x.Fee,
                    IssuedOn = x.IssuedOn,
                    RecipientName = x.Recipient.Username
                }).ToList();

            return this.View(viewModel);
        }
    }
}
