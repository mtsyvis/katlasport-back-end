namespace KatlaSport.Services.ManagerControl
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IManagerService
    {
        Task<List<Manager>> GetManagersAsync(int start, int amount);

        Task<Manager> GetManagerAsync(int managerId);

        Task<Manager> CreateManagerAsync(UpdateManagerRequest createRequest);

        Task<Manager> UpdateManagerAsync(int customerId, UpdateManagerRequest updateRequest);

        Task DeleteCustomerAsync(int customerId);
    }
}
