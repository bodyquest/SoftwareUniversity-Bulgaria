namespace Spice.Services.Admin
{
    using Spice.Services.Admin.Models.Coupons;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICouponService
    {
        Task<IEnumerable<AdminCouponListingServiceModel>> AllAsync();


    }
}
