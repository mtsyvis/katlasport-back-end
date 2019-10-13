using AutoMapper;
using DataAccessManager = KatlaSport.DataAccess.ManagerCatalogue.Manager;

namespace KatlaSport.Services.ManagerControl
{
    public class ManagerControlMappingProfile : Profile
    {
        public ManagerControlMappingProfile()
        {
            CreateMap<DataAccessManager, Manager>();
            CreateMap<UpdateManagerRequest, DataAccessManager>();
        }
    }
}
