namespace Musaca.Web.Controllers
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using Musaca.Models;
    using Musaca.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Result;
    using SIS.MvcFramework.Attributes.Security;

    public class OrdersController : Controller
    {
        private readonly IOrderService orderSrervice;

        public OrdersController(IOrderService orderSrervice)
        {
            this.orderSrervice = orderSrervice;
        }

        
        [Authorize]
        public IActionResult Cashout()
        {
            Order currentActiveOrder = this.orderSrervice.GetActiveOrderByCashierId(this.User.Id);

            this.orderSrervice.CompleteOrderById(currentActiveOrder.Id.ToString(), this.User.Id);

            return this.Redirect("/");
        }
    }
}
