using AutoMapper;
using DataAccessOrder = KatlaSport.DataAccess.OrderCatalogue.Order;
using DataAccessOrderProductItem = KatlaSport.DataAccess.OrderCatalogue.OrderProductItem;

namespace KatlaSport.Services.OrderManagement
{
    public sealed class OrderManagementMappingProfile : Profile
    {
        public OrderManagementMappingProfile()
        {
            CreateMap<DataAccessOrder, OrderListItem>();
            CreateMap<DataAccessOrder, Order>();
            CreateMap<UpdateOrderRequest, DataAccessOrder>();
            CreateMap<OrderProductListItem, DataAccessOrderProductItem>();
        }
    }
}
