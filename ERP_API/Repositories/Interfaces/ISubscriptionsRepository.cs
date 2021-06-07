using ERP_API.DTOs;
using ERP_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP_API.Repositories.Interfaces
{
    public interface ISubscriptionsRepository
    {
        /// <summary>
        /// Gets all subscriptions.
        /// </summary>
        /// <returns><see cref="IEnumerable{SubscriptionDTO}"/>List with all subscriptions.</returns>
        Task<IEnumerable<Subscription>> GetAllSubscriptionsAsync();
    }
}
