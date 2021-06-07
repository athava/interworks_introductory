using AutoMapper;
using ERP_API.DTOs;
using ERP_API.Models;
using ERP_API.Repositories.Interfaces;
using ERP_API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_API.Services.Implementations
{
    public class DiscountsService : IDiscountsService
    {
        private readonly IDiscountsRepository _discountRepository;
        private readonly IMapper _mapper;

        public DiscountsService(IDiscountsRepository discountRepository, IMapper mapper)
        {
            _discountRepository = discountRepository ?? throw new ArgumentNullException(nameof(discountRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task DeleteDiscountAsync(int discountId)
        {
            if (discountId <= default(int))
            {
                throw new ArgumentNullException(nameof(discountId));
            }

            await _discountRepository.DeleteDiscountAsync(discountId);
        }

        public async Task<int> AddDiscountAsync(DiscountDTO discount)
        {
            if (discount is null)
            {
                throw new ArgumentNullException(nameof(discount));
            }

            return await _discountRepository.AdddiscountAsync(_mapper.Map<Discount>(discount));
        }

        public async Task<IEnumerable<DiscountDTO>> GetAllDiscountsAsync()
        {
            return _mapper.Map<IEnumerable<DiscountDTO>>(await _discountRepository.GetAllDiscountsAsync());
        }

        public async Task<DiscountDTO> GetDiscountAsync(int discountId)
        {
            return _mapper.Map<DiscountDTO>(await _discountRepository.GetDiscountAsync(discountId));
        }

        public async Task<int> UpdateDiscountAsync(DiscountDTO discount)
        {
            if (discount is null)
            {
                throw new ArgumentNullException(nameof(discount));
            }

            return await _discountRepository.UpdateDiscountAsync(_mapper.Map<Discount>(discount));
        }
    }
}
