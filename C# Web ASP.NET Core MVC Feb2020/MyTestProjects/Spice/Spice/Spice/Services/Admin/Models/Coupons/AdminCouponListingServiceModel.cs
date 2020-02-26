namespace Spice.Services.Admin.Models.Coupons
{
    using Spice.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdminCouponListingServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CouponType { get; set; }

        public CouponType ECouponType { get; set; }

        public double Discount { get; set; }

        public double MinimumAmount { get; set; }

        public byte[] Picture { get; set; }

        public bool IsActive { get; set; }
    }
}
