namespace Spice.Models.ViewModels
{
    using Spice.Services.Admin.Models.Coupons;
    using Spice.Services.Admin.Models.MenuItems;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class IndexViewModel
    {
        public IEnumerable<AdminCouponListingServiceModel> Coupons { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<AdminMenuItemVM> MenuItems { get; set; }
    }
}
