using ERP_API.Models;
using ERP_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ERP_API.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly interworksDBContext _context;

        public CustomerRepository(interworksDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> AddcustomerAsync(Customer customer)
        {
            var newCustomer = await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return newCustomer.Entity.Id;
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer == null)
            {
                throw new InvalidOperationException();
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers
            .FromSqlRaw("exec sp_GetAllCustomers")
            .ToListAsync();
        }

        public async Task<Customer> GetCustomerAsync(int customerId)
        {
            return await _context.Customers.Include(x => x.CustomerSubscriptions).ThenInclude(x => x.SubscriptionDiscounts).Where(x => x.Id == customerId).SingleOrDefaultAsync();
        }

        public async Task<int> UpdateCustomerAsync(Customer customer)
        {
            var oldCustomer = await _context.Customers.FindAsync(customer.Id);
            if (oldCustomer == null)
            {
                throw new InvalidOperationException();
            }
            oldCustomer.CustomerName = customer.CustomerName;
            oldCustomer.CustomerType = customer.CustomerType;

            _context.Customers.Update(oldCustomer);
            await _context.SaveChangesAsync();

            return oldCustomer.Id;
        }

    }
}
