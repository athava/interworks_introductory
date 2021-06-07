using ERP_API.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP_API.Services.Interfaces
{
    public interface ISubscriptionsService
    {
        /// <summary>
        /// Gets all subscriptions.
        /// </summary>
        /// <returns><see cref="IEnumerable{SubscriptionDTO}"/>List with all subscriptions.</returns>
        Task<IEnumerable<SubscriptionDTO>> GetAllSubscriptionsAsync();
    }
}
