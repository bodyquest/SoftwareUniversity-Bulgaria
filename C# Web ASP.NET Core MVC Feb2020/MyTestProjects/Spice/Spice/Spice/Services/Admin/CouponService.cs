namespace Spice.Services.Admin
{
    using Microsoft.EntityFrameworkCore;
    using Spice.Data;
    using Spice.Models;
    using Spice.Models.Enums;
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

            var type = ((CouponType)(int.Parse(model.CouponType)));
            var coupon = new Coupon()
            {
                Id = model.Id,
                Name = model.Name,
                CouponType = model.CouponType,
                Picture = model.Picture,
                ECouponType = type,
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

        public async Task<AdminCouponListingServiceModel> GetByIdAsync(int id)
        {
            var couponFromDb = await this.context.Coupons.FirstOrDefaultAsync(x => x.Id == id);

            if (couponFromDb == null)
            {
                return null;
            }

            var model = new AdminCouponListingServiceModel()
            {
                Id = couponFromDb.Id,
                Name = couponFromDb.Name,
                CouponType = couponFromDb.CouponType,
                Picture = couponFromDb.Picture,
                ECouponType = couponFromDb.ECouponType,
                Discount = couponFromDb.Discount,
                MinimumAmount = couponFromDb.MinimumAmount,
                IsActive = couponFromDb.IsActive
            };
            
            return model;
        }

        public async Task<bool> UpdateAsync(AdminCouponListingServiceModel model)
        {
            var couponFromDb = await this.context.Coupons.FirstAsync(x => x.Id == model.Id);
            var type = ((CouponType)(int.Parse(model.CouponType)));

            couponFromDb.Name = model.Name;
            couponFromDb.CouponType = model.CouponType;
            couponFromDb.Picture = model.Picture;
            couponFromDb.ECouponType = type;
            couponFromDb.Discount = model.Discount;
            couponFromDb.MinimumAmount = model.MinimumAmount;
            couponFromDb.IsActive = model.IsActive;

            var result = this.context.Update(couponFromDb);
            var success = await this.context.SaveChangesAsync();

            if (success > 0)
            {
                return true;
            }

            return false;
        }
    }
}
