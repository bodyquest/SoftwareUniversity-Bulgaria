namespace FastFood.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using System;
    using System.Linq;
    using AutoMapper;

    using Data;
    using FastFood.Models;
    using ViewModels.Orders;
    using FastFood.Models.Enums;
    using AutoMapper.QueryableExtensions;

    public class OrdersController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public OrdersController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            var viewOrder = new CreateOrderViewModel
            {
                Items = this.context.Items
                .Select(x => x.Name)
                .ToList(),

                Employees = this.context.Employees
                .Where(x => x.Position.Name == "Waiter")
                .Select(x => x.Name)
                .ToList(),
            };

            return this.View(viewOrder);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderInputModel model)
        {
            Item item = this.context.Items
                .FirstOrDefault(x => x.Name == model.ItemName);
            Employee employee = this.context.Employees
                .FirstOrDefault(x => x.Name == model.EmployeeName);

            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            };
            

            Order order = this.mapper.Map<Order>(model);
            order.DateTime = DateTime.Now;
            order.Type = Enum.Parse<OrderType>(model.OrderType);
            order.Employee = employee;

            order.OrderItems.Add(new OrderItem
            {
                Item = item,
                Order = order,
                Quantity = model.Quantity
            });

            this.context.Orders.Add(order);

            this.context.SaveChanges();

            return this.RedirectToAction("All", "Orders");
        }

        public IActionResult All()
        {
            var orders = this.context.Orders
                .ProjectTo<OrderAllViewModel>(mapper.ConfigurationProvider)
                .ToList();

            return this.View(orders);
        }
    }
}
