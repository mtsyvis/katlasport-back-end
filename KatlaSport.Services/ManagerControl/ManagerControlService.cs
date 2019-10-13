namespace KatlaSport.Services.ManagerControl
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ManagerControlService : IManagerService
    {
        public Task<List<Manager>> GetManagersAsync(int start, int amount)
        {
            throw new System.NotImplementedException();
        }

        public Task<Manager> GetManagerAsync(int managerId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Manager> CreateManagerAsync(UpdateManagerRequest createRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<Manager> UpdateManagerAsync(int customerId, UpdateManagerRequest updateRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteCustomerAsync(int customerId)
        {
            throw new System.NotImplementedException();
        }
    }
}
