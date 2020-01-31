namespace Musaca.Web.ViewModels.Users
{
    using Musaca.Web.ViewModels.Orders;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserProfileViewModel
    {
        public UserProfileViewModel()
        {
            this.Orders = new List<OrderProfileViewModel>();
        }

        public List<OrderProfileViewModel> Orders { get; set; }
    }
}
