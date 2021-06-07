using ERP_API.DTOs;
using ERP_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionsService _subscriptionService;
        private readonly ILogger _logger;

        public SubscriptionsController(ISubscriptionsService subscriptionService, ILogger<SubscriptionsController> logger)
        {
            _subscriptionService = subscriptionService ?? throw new ArgumentNullException(nameof(subscriptionService));
            _logger = logger;
        }

        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns><see cref="IEnumerable{CustomerDTO}" /></returns>
        [HttpGet]
        public async Task<IEnumerable<SubscriptionDTO>> GetAllSubscriptionsAsync()
        {
            return await _subscriptionService.GetAllSubscriptionsAsync();
        }

    }
}
