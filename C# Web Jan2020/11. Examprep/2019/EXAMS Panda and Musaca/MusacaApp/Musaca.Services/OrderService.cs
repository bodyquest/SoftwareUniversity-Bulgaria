namespace Musaca.Services
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Musaca.Data;
    using Musaca.Models;
    using Musaca.Models.Enums;
    using Microsoft.EntityFrameworkCore;

    public class OrderService : IOrderService
    {
        private readonly MusacaDbContext context;

        public OrderService(MusacaDbContext context)
        {
            this.context = context;
        }

        public Order CreateOrder(Order order)
        {

            this.context.Add(order);
            this.context.SaveChanges();

            return order;
        }

        public Order CompleteOrderById(string orderId, string userId)
        {
            Order orderFromDb = this.context.Orders.SingleOrDefault(x => x.Id == int.Parse(orderId));

            orderFromDb.IssuedOn = DateTime.UtcNow;
            orderFromDb.Status = OrderStatus.Completed;
            this.context.Update(orderFromDb);

            this.CreateOrder(new Order() { CashierId = userId });

            return orderFromDb;
        }

        public List<Order> GetAllCompletedOrdersByCashierId(string cashierId)
        {
            List<Order> ordersFromDb = this.context.Orders
                .Include(order => order.Products)
                .ThenInclude(orderProduct => orderProduct.Product)
                .Include(order => order.Cashier)
                .Where(x => x.CashierId == cashierId)
                .Where(x => x.Status == OrderStatus.Completed)
                .ToList();
              
            return ordersFromDb;
        }

        public Order GetActiveOrderByCashierId(string cashierId)
        {
            Order orderFromDb = this.context.Orders
                .Include(order => order.Products)
                .ThenInclude(orderProduct => orderProduct.Product)
                .Include(order => order.Cashier)
                .SingleOrDefault(x => x.Status == OrderStatus.Active && x.CashierId == cashierId);

            return orderFromDb;
        }

        public bool AddProductToActiveOrder(string productId, string userId)
        {
            Product productFromDb = this.context.Products.FirstOrDefault(x => x.Id == productId);
            Order currentActiveOrder = this.GetActiveOrderByCashierId(userId);
            currentActiveOrder.Products.Add(new OrderProduct()
            {
                Product = productFromDb
            });

            this.context.Orders
                .Update(currentActiveOrder);
            this.context.SaveChanges();

            return true;
        }
    }
}
