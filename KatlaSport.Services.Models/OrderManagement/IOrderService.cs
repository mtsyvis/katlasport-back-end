using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.OrderManagement
{
    public interface IOrderService
    {
        Task<List<OrderListItem>> GetOrdersAsync();

        Task<List<OrderListItem>> GetOrdersByCustomerAsync(int customerId);

        Task<List<OrderProductListItem>> GetProductsInfo(int orderId);

        Task<OrderListItem> GetOrderAsync(int orderId);

        Task<Order> CreateOrderAsync(UpdateOrderRequest createRequest);

        Task<Order> UpdateOrderAsync(int orderId, UpdateOrderRequest updateRequest);

        Task SetOrderStatusAsync(int orderId, int statusId);

        Task DeleteOrderAsync(int orderId);

        Task AddProductToOrder(int orderId, OrderProductListItem productListItem);
    }
}
