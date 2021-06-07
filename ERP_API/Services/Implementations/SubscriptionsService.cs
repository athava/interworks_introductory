using AutoMapper;
using ERP_API.DTOs;
using ERP_API.Repositories.Interfaces;
using ERP_API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_API.Services.Implementations
{
    public class SubscriptionsService : ISubscriptionsService
    {
        private readonly ISubscriptionsRepository _subscriptionRepository;
        private readonly IMapper _mapper;

        public SubscriptionsService(ISubscriptionsRepository subscriptionRepository, IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository ?? throw new ArgumentNullException(nameof(subscriptionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<SubscriptionDTO>> GetAllSubscriptionsAsync()
        {
            return _mapper.Map<IEnumerable<SubscriptionDTO>>(await _subscriptionRepository.GetAllSubscriptionsAsync());

        }
    }
}
