using ERP_API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP_API.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns><see cref="IEnumerable{Customer}"/>List with active customers.</returns>
        Task<IEnumerable<Customer>> GetAllCustomersAsync();

        /// <summary>
        /// Get a specific customer.
        /// </summary>
        /// <param name="customerId" >The customer's id.</param>
        /// <returns><see cref="Customer"/>The customer with the specified id.</returns>
        Task<Customer> GetCustomerAsync(int customerId);

        /// <summary>
        /// Add a new customer.
        /// </summary>
        /// <param name="customer">A customer.</param>
        /// <returns><see cref="int"/> the customer new identifier.</returns>
        Task<int> AddcustomerAsync(Customer customer);

        /// <summary>
        /// Updates an existing customer.
        /// </summary>
        /// <param name="customer">A customer.</param>
        /// <exception cref="InvalidOperationException">CustomerType or customerTitle are not valid.</exception>
        /// <returns><see cref="int"/> the customer new identifier.</returns>
        Task<int> UpdateCustomerAsync(Customer customer);

        /// <summary>
        /// Deletes the specified customer.
        /// </summary>
        /// <param name="customerId">The customer's id.</param>
        Task DeleteCustomerAsync(int customerId);
    }
}
