namespace Spice.Services.Admin
{
    using Microsoft.EntityFrameworkCore;
    using Spice.Data;
    using Spice.Models;
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

        public async Task<bool> CreateAsync(AdminCouponListingServiceModel model)
        {
            var couponExists = await this.context.Coupons.AnyAsync(c => c.Name == model.Name);

            var coupon = new Coupon()
            {
                Id = model.Id,
                Name = model.Name,
                CouponType = model.CouponType,
                Picture = model.Picture,
                ECouponType = model.ECouponType,
                Discount = model.Discount,
                MinimumAmount = model.MinimumAmount,
                IsActive = model.IsActive
            };

            if (!couponExists)
            {
                await this.context.Coupons.AddAsync(coupon);
                int result = await this.context.SaveChangesAsync();

                if (result > 0)
                {
                    return true;
                }

                return false;
            }

            return false;
        }


    }
}
