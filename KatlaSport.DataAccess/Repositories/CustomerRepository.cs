namespace KatlaSport.DataAccess.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using KatlaSport.DataAccess.CustomerCatalogue;

    public class CustomerRepository : IRepository<Customer>
    {
        private readonly ICustomerContext _context;

        public CustomerRepository(ICustomerContext context)
        {
            _context = context;
        }

        public void Add(Customer obj)
        {
            _context.Customers.Add(obj);
        }

        public void Delete(Customer obj)
        {
            _context.Customers.Remove(obj);
        }

        public void Update(Customer obj)
        {
            var customer = GetItem(obj.Id);
            customer = obj;
        }

        public Customer GetItem(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }

        public IQueryable<Customer> GetItems(Expression<Func<Customer, bool>> predicate)
        {
            return _context.Customers.Where(predicate);
        }

        public IQueryable<Customer> GetItems()
        {
            return _context.Customers;
        }

        public void SaveChanges()
        {
            _context.SaveChangesAsync();
        }
    }
}
