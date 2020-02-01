namespace Panda.App.Controllers
{
    using System.Linq;
    using System.Collections.Generic;

    using Panda.App.ViewModels.Packages;
    using Panda.Models.Enums;
    using Panda.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Result;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;

    public class PackagesController : Controller
    {
        private readonly IUserService userservice;
        private readonly IPackageService packageService;

        public PackagesController(IPackageService packageService, IUserService userservice)
        {
            this.userservice = userservice;
            this.packageService = packageService;
        }

        [Authorize]
        public IActionResult Create()
        {
            IEnumerable<string> allRecipients = this.userservice.GetUsernames();

            return this.View(allRecipients);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(PackageCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Packages/Create");
            }

            this.packageService.Create(model.Description, model.Weight, model.ShippingAddress, model.RecipientName);

            return this.Redirect("/Packages/Pending");
        }

        [Authorize]
        public IActionResult Delivered()
        {
            List<PackageViewModel> allDeliveredPackages = 
                this.packageService
                .GetAllByStatus(PackageStatus.Delivered, this.User.Id)
                .Select(x => new PackageViewModel 
                {
                    Id = x.Id,
                    Description = x.Description,
                    Weight = x.Weight,
                    ShippingAddress = x.ShippingAddress,
                    RecipientName = x.Recipient.Username
                }).ToList();

            return this.View(new PackagesListViewModel { Packages = allDeliveredPackages });
        }

        [Authorize]
        public IActionResult Pending()
        {
            List<PackageViewModel> allPendingPackages = 
                this.packageService.GetAllByStatus(PackageStatus.Pending, this.User.Id)
            .Select(x => new PackageViewModel
            {
                Id = x.Id,
                Description = x.Description,
                Weight = x.Weight,
                ShippingAddress = x.ShippingAddress,
                RecipientName = x.Recipient.Username
            }).ToList();

            return this.View(new PackagesListViewModel { Packages = allPendingPackages });
        }

        [Authorize]
        public IActionResult Deliver(string id)
        {
            this.packageService.Deliver(id);
            return this.Redirect("/Packages/Delivered");
        }
    }
}
