using AutoMapper;
using DataAccessOrder = KatlaSport.DataAccess.OrderCatalogue.Order;

namespace KatlaSport.Services.OrderManagement
{
    public sealed class OrderManagementMappingProfile : Profile
    {
        public OrderManagementMappingProfile()
        {
            CreateMap<DataAccessOrder, OrderListItem>();
            CreateMap<DataAccessOrder, Order>();
            CreateMap<UpdateOrderRequest, DataAccessOrder>();
        }
    }
}
