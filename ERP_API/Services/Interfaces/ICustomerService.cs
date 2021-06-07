using ERP_API.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP_API.Services.Interfaces
{
    public interface ICustomerService
    {
        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns><see cref="IEnumerable{CustomerDTO}"/>List with active customers.</returns>
        Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync();

        /// <summary>
        /// Get a specific customer.
        /// </summary>
        /// <param name="customerId" >The customer's id.</param>
        /// <returns><see cref="CustomerDTO"/>The customerDTO.</returns>
        Task<CustomerDTO> GetCustomerAsync(int customerId);

        /// <summary>
        /// Add a new customer.
        /// </summary>
        /// <param name="customer">A customer.</param>
        /// <exception cref="ArgumentNullException">customer is not valid.</exception>
        /// <returns><see cref="int"/> the customer new identifier.</returns>
        Task<int> AddCustomerAsync(CustomerDTO customer);

        /// <summary>
        /// Updates an existing customer.
        /// </summary>
        /// <param name="customer">A customer.</param>
        /// <exception cref="ArgumentNullException">Customer is not valid.</exception>
        /// <returns><see cref="int"/> the customer new identifier.</returns>
        Task<int> UpdateCustomerAsync(CustomerDTO customer);

        /// <summary>
        /// Deletes the specified customer.
        /// </summary>
        /// <param name="customerId">The customer's id.</param>
        /// <exception cref="ArgumentOutOfRangeException">Customer id is not valid.</exception>
        Task DeleteCustomerAsync(int customerId);
    }
}
