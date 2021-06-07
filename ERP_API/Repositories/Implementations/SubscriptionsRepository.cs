using ERP_API.Models;
using ERP_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP_API.Repositories.Implementations
{
    public class SubscriptionsRepository : ISubscriptionsRepository
    {
        private readonly interworksDBContext _context;

        public SubscriptionsRepository(interworksDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Subscription>> GetAllSubscriptionsAsync()
        {
            var x = await _context.Subscriptions
          .FromSqlRaw("exec sp_GetAllSubscriptions")
          .ToListAsync();
            return x;
        }
    }
}
