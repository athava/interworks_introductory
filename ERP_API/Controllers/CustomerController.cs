using ERP_API.CustomExceptions;
using ERP_API.DTOs;
using ERP_API.Models;
using ERP_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger _logger;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _logger = logger;
        }

        /// <summary>
        /// Gets all Customers.
        /// </summary>
        /// <returns><see cref="IEnumerable{CustomerDTO}" /></returns>
        [HttpGet]
        public async Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync()
        {
            return await _customerService.GetAllCustomersAsync();
        }

        /// <summary>
        /// Get a specific Customer.
        /// </summary>
        /// <param name="customerId">The customer's id.</param>
        /// <returns><see cref="ActionResult" /></returns>
        [HttpGet]
        [Route("{customerId}")]
        public async Task<ActionResult> GetCustomerAsync(int customerId)
        {
            try
            {
                return Ok(await _customerService.GetCustomerAsync(customerId).ConfigureAwait(false));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (CustomException ex)
            {
                _logger.LogInformation(ex.Message);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Add a new Customer.
        /// </summary>
        /// <param name="customer">A customer.</param>
        /// <returns><see cref="ActionResult" /></returns>
        [HttpPost]
        public async Task<ActionResult> AddCustomerAsync(CustomerDTO customer)
        {
            try
            {
                var newCustomerId = await _customerService.AddCustomerAsync(customer);
                return Ok(newCustomerId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing Customer.
        /// </summary>
        /// <param name="customer">A customer.</param>
        /// <returns><see cref="ActionResult" /></returns>
        [HttpPut]
        public async Task<ActionResult> UpdateCustomerAsync(CustomerDTO customer)
        {
            try
            {
                var customerId = await _customerService.UpdateCustomerAsync(customer).ConfigureAwait(false);
                return Ok(customerId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes the specified Customer.
        /// </summary>
        /// <param name="customerId">The customer's id.</param>
        /// <returns><see cref="ActionResult" /></returns>
        [HttpDelete]
        [Route("{customerId}")]
        public async Task<ActionResult> DeleteCustomerAsync(int customerId)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(customerId).ConfigureAwait(false);
                return Ok(true);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}