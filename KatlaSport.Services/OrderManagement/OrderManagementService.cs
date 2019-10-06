namespace KatlaSport.Services.OrderManagement
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using KatlaSport.DataAccess.CustomerCatalogue;
    using KatlaSport.DataAccess.ManagerCatalogue;
    using KatlaSport.DataAccess.OrderCatalogue;
    using KatlaSport.DataAccess.ProductStoreHive;

    public class OrderManagementService : IOrderService
    {
        private readonly IOrderCatalogueContext _orderCatalogueContext;
        private readonly ICustomerContext _customerContext;
        private readonly IManagerContext _managerContext;
        private readonly IProductStoreHiveContext _productStoreHiveContext;

        public OrderManagementService(IOrderCatalogueContext orderCatalogueContext, ICustomerContext customerContext, IManagerContext managerContext, IProductStoreHiveContext productStoreHiveContext)
        {
            _orderCatalogueContext =
                orderCatalogueContext ?? throw new ArgumentNullException(nameof(orderCatalogueContext));
            _customerContext = customerContext ?? throw new ArgumentNullException(nameof(customerContext));
            _managerContext = managerContext ?? throw new ArgumentNullException(nameof(managerContext));
            _productStoreHiveContext = productStoreHiveContext
                                            ?? throw new ArgumentNullException(nameof(productStoreHiveContext));
        }

        public Task<List<OrderListItem>> GetOrdersAsync(int start, int amount)
        {
            throw new NotImplementedException();
        }

        public Task<Order> CreateOrderAsync(UpdateOrderRequest createRequest)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrderAsync(int orderId, UpdateOrderRequest updateRequest)
        {
            throw new NotImplementedException();
        }

        public Task SetOrderStatusAsync(int statusId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
