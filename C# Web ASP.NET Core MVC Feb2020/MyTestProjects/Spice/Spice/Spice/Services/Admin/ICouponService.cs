namespace Spice.Services.Admin
{
    using Spice.Services.Admin.Models.Coupons;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICouponService
    {
        Task<IEnumerable<AdminCouponListingServiceModel>> AllAsync();

        Task<bool> CreateAsync(AdminCouponListingServiceModel model);
    }
}
