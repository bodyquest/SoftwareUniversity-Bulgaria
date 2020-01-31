namespace Musaca.Services
{
    using System.Collections.Generic;

    using Musaca.Models;

    public interface IOrderService
    {
        bool AddProductToActiveOrder(string productId, string userId);

        Order CreateOrder(Order order);

        Order CompleteOrderById(string orderId, string userId);

        List<Order> GetAllCompletedOrdersByCashierId(string userId);

        Order GetActiveOrderByCashierId(string cashierId);
    }
}
