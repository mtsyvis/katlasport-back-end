namespace KatlaSport.Services.OrderManagement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using KatlaSport.DataAccess;
    using KatlaSport.DataAccess.CustomerCatalogue;
    using KatlaSport.DataAccess.ManagerCatalogue;
    using KatlaSport.DataAccess.OrderCatalogue;
    using KatlaSport.DataAccess.ProductStore;

    public class OrderManagementService : IOrderService
    {
        private readonly IOrderCatalogueContext _orderCatalogueContext;
        private readonly ICustomerContext _customerContext;
        private readonly IManagerContext _managerContext;
        private readonly IProductStoreContext _productStoreContext;

        public OrderManagementService(IOrderCatalogueContext orderCatalogueContext, ICustomerContext customerContext, IManagerContext managerContext, IProductStoreContext productStoreContext)
        {
            _orderCatalogueContext =
                orderCatalogueContext ?? throw new ArgumentNullException(nameof(orderCatalogueContext));
            _customerContext = customerContext ?? throw new ArgumentNullException(nameof(customerContext));
            _managerContext = managerContext ?? throw new ArgumentNullException(nameof(managerContext));
            _productStoreContext = productStoreContext
                                            ?? throw new ArgumentNullException(nameof(productStoreContext));
        }

        public async Task<List<OrderListItem>> GetOrdersAsync()
        {
            var dbOrders = await _orderCatalogueContext.Orders.OrderBy(o => o.Id).ToArrayAsync();
            var orders = dbOrders.Select(o => Mapper.Map<OrderListItem>(o)).ToList();

            foreach (var order in orders)
            {
                order.OrderStatus = _orderCatalogueContext.OrderStatuses.FirstOrDefault(o => o.Id == order.StatusId).Name;
            }

            return orders;
        }

        public async Task<Order> CreateOrderAsync(UpdateOrderRequest createRequest)
        {
            var dbOrder = Mapper.Map<UpdateOrderRequest, KatlaSport.DataAccess.OrderCatalogue.Order>(createRequest);
            dbOrder.CustomerId = 1; // Add logic later
            dbOrder.ManagerId = 2; // Add logic later
            dbOrder.TotalCost = createRequest.ProductAmount * _productStoreContext.Items
                                    .FirstOrDefault(i => i.Product.Id == createRequest.ProductId).Product.Price;

            dbOrder.OrderDate = DateTime.UtcNow;
            dbOrder.StatusId = 1; // Don't know how to realize logic using enum
            _orderCatalogueContext.Orders.Add(dbOrder);

            await _orderCatalogueContext.SaveChangesAsync();

            return Mapper.Map<Order>(dbOrder);
        }

        public async Task<Order> UpdateOrderAsync(int orderId, UpdateOrderRequest updateRequest)
        {
            var dbOrders = await _orderCatalogueContext.Orders.Where(o => o.Id == orderId).ToArrayAsync();
            if (dbOrders.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbOrder = dbOrders[0];
            Mapper.Map(updateRequest, dbOrder);

            dbOrder.TotalCost += RecalculateOrderTotalCost();

            await _orderCatalogueContext.SaveChangesAsync();

            return Mapper.Map<Order>(dbOrder);

            decimal RecalculateOrderTotalCost()
            {
                // if (dbOrder.Products.Any(p => p.ItemId == updateRequest.ProductId))
                // {
                //
                // }
                // _productStoreContext.Items.FirstOrDefault(i => i.ProductId == updateRequest.ProductId)?.Product.Price
                //     * updateRequest.ProductAmount;
                return 0;
            }
        }

        public Task SetOrderStatusAsync(int orderId, int statusId)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var dbOrders = await _orderCatalogueContext.Orders.Where(o => o.Id == orderId).ToArrayAsync();
            if (dbOrders.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbOrder = dbOrders[0];

            _orderCatalogueContext.Orders.Remove(dbOrder);
            await _orderCatalogueContext.SaveChangesAsync();
        }
    }
}
