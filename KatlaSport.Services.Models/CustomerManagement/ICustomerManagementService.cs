using System.Collections.Generic;

namespace KatlaSport.Services.CustomerManagement
{
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a customer management service.
    /// </summary>
    public interface ICustomerManagementService
    {
        Task<List<CustomerFullInfo>> GetCustomersAsync(int start, int amount);

        Task<CustomerFullInfo> GetCustomerAsync(int customerId);

        Task<int> GetCustomerAmount();

        Task<CustomerFullInfo> CreateCustomer(UpdateCustomerRequest createRequest);

        int GetAmount();

        IList<CustomerBriefInfo> GetBriefInfo(int start, int amount);

        IList<CustomerFullInfo> GetFullInfo(IEnumerable<int> ids);
    }
}
