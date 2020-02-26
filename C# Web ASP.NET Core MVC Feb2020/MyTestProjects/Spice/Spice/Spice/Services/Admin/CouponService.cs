namespace Spice.Services.Admin
{
    using Microsoft.EntityFrameworkCore;
    using Spice.Data;
    using Spice.Services.Admin.Models.Coupons;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CouponService : ICouponService
    {
        private readonly ApplicationDbContext context;

        public CouponService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<AdminCouponListingServiceModel>> AllAsync()
        {
            var coupons = await this.context
                .Coupons
                .OrderBy(x => x.MinimumAmount)
                .Select(x => new AdminCouponListingServiceModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CouponType = x.CouponType,
                    ECouponType = x.ECouponType,
                    MinimumAmount = x.MinimumAmount,
                    Picture = x.Picture,
                    Discount = x.Discount,
                    IsActive = x.IsActive
                })
                .ToListAsync();

            return coupons;
        }

        // public async Task<> Async()
        // { 
        //
        // }


    }
}
