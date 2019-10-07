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
        public CustomerManagementService(ICustomerContext context, int constructorOverwrite)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CustomerFullInfo>> GetCustomersAsync(int start, int amount)
        {
            var dbCustomers = await _repository.GetItems(c => c.Id >= start && c.Id <= start + amount).ToListAsync(); // Need to change

            return dbCustomers.Select(c => Mapper.Map<CustomerFullInfo>(c)).ToList();
        }

        public async Task<CustomerFullInfo> GetCustomerAsync(int customerId)
        {
            var dbCustomers = await _repository.GetItems(i => i.Id == customerId).ToArrayAsync();

            if (dbCustomers.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            return Mapper.Map<CustomerFullInfo>(dbCustomers[0]);
        }

        public async Task<int> GetCustomerAmountAsync()
        {
            return await _repository.GetItems().CountAsync();
        }

        public async Task<CustomerFullInfo> CreateCustomerAsync(UpdateCustomerRequest createRequest)
        {
            var dbCustomer = Mapper.Map<UpdateCustomerRequest, Customer>(createRequest);
            _repository.Add(dbCustomer);
            await _repository.SaveChanges();

            return Mapper.Map<CustomerFullInfo>(dbCustomer);
        }

        public async Task<CustomerFullInfo> UpdateCustomerAsync(int customerId, UpdateCustomerRequest updateRequest)
        {
            var dbCustomers = await _repository.GetItems(i => i.Id == customerId).ToArrayAsync();

            if (dbCustomers.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            var dbCustomer = dbCustomers[0];

            Mapper.Map(updateRequest, dbCustomer);
            _repository.Update(dbCustomer);
            await _repository.SaveChanges();

            return Mapper.Map<CustomerFullInfo>(dbCustomer);
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            var dbCustomers = await _repository.GetItems(i => i.Id == customerId).ToArrayAsync();

            if (dbCustomers.Length == 0)
            {
                throw new RequestedResourceNotFoundException();
            }

            _repository.Delete(dbCustomers[0]);
            await _repository.SaveChanges();
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
