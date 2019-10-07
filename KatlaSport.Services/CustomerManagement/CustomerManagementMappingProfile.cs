using AutoMapper;
using DataAccessCustomer = KatlaSport.DataAccess.CustomerCatalogue.Customer;

namespace KatlaSport.Services.CustomerManagement
{
    public sealed class CustomerManagementMappingProfile : Profile
    {
        public CustomerManagementMappingProfile()
        {
            CreateMap<DataAccessCustomer, CustomerFullInfo>();
            CreateMap<DataAccessCustomer, CustomerBriefInfo>();
            CreateMap<UpdateCustomerRequest, DataAccessCustomer>();
        }
    }
}
