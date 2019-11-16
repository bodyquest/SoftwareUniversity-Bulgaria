﻿namespace FastFood.Web.Controllers
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
                Items = this.context.Items.Select(x => x.Id).ToList(),
                Employees = this.context.Employees.Select(x => x.Id).ToList(),
            };

            return this.View(viewOrder);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var order = this.mapper.Map<Order>(model);
            order.Type = Enum.Parse<OrderType>(model.OrderType);

            order.OrderItems.Add(new OrderItem
            {
                ItemId = model.ItemId,
                Order = order,
                Quantity = model.Quantity
            });


            order.DateTime = DateTime.Now;

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
