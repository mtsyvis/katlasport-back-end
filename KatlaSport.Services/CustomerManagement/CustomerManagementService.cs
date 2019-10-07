using System;
using System.Collections.Generic;

namespace KatlaSport.Services.CustomerManagement
{
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using KatlaSport.DataAccess;
    using KatlaSport.DataAccess.CustomerCatalogue;

    public class CustomerManagementService : ICustomerManagementService
    {
        // private readonly ICustomerContext _context;
        //
        // public CustomerManagementService(ICustomerContext context)
        // {
        //     _context = context ?? throw new ArgumentNullException(nameof(context));
        // }
        //
        // public int GetAmount()
        // {
        //     return _context.Customers.Count();
        // }
        //
        // public IList<CustomerBriefInfo> GetBriefInfo(int start, int amount)
        // {
        //     return _context.Customers.Skip(start).Take(amount).Select(c => new CustomerBriefInfo
        //     {
        //         Id = c.Id,
        //         Name = c.Name
        //     }).ToArray();
        // }
        //
        // public IList<CustomerFullInfo> GetFullInfo(IEnumerable<int> ids)
        // {
        //     if (ids == null)
        //     {
        //         throw new ArgumentNullException(nameof(ids));
        //     }
        //
        //     var idArray = ids.ToArray();
        //     return _context.Customers.Where(c => idArray.Contains(c.Id)).Select(c => new CustomerFullInfo
        //     {
        //         Id = c.Id,
        //         Name = c.Name,
        //         Address = c.Address,
        //         Phone = c.Phone
        //     }).ToArray();
        // }

        private readonly IRepository<Customer> _repository;

        public CustomerManagementService(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        // Old Implementations
        public CustomerManagementService(ICustomerContext context = null)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CustomerFullInfo>> GetCustomersAsync(int start, int amount)
        {
            var dbCustomers = await _repository.GetItems(c => c.Id >= start && c.Id <= start + amount).ToListAsync(); // Need to change

            return dbCustomers.Select(c => Mapper.Map<CustomerFullInfo>(c)).ToList();
        }

        public Task<CustomerFullInfo> GetCustomerAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCustomerAmount()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerFullInfo> CreateCustomer(UpdateCustomerRequest createRequest)
        {
            throw new NotImplementedException();
        }

        // Old Implementations
        public int GetAmount()
        {
            throw new NotImplementedException();
        }

        public IList<CustomerBriefInfo> GetBriefInfo(int start, int amount)
        {
            throw new NotImplementedException();
        }

        public IList<CustomerFullInfo> GetFullInfo(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerFullInfo> CreateCustomer()
        {
            throw new NotImplementedException();
        }
    }
}
