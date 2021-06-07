using ERP_API.Models;
using ERP_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP_API.Repositories.Implementations
{
    public class DiscountsRepository : IDiscountsRepository
    {
        private readonly interworksDBContext _context;

        public DiscountsRepository(interworksDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> AdddiscountAsync(Discount discount)
        {
            var newDiscount = await _context.Discounts.AddAsync(discount);

            await _context.SaveChangesAsync();

            return newDiscount.Entity.Id;
        }

        public async Task DeleteDiscountAsync(int discountId)
        {
            var discount = await _context.Discounts.FindAsync(discountId);
            if (discount == null)
            {
                throw new InvalidOperationException();
            }
            _context.Discounts.Remove(discount);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Discount>> GetAllDiscountsAsync()
        {
            return await _context.Discounts
            .FromSqlRaw("exec sp_GetAllDiscounts")
            .ToListAsync();
        }

        public async Task<Discount> GetDiscountAsync(int discountId)
        {
            return await _context.Discounts.FindAsync(discountId);
        }

        public async Task<int> UpdateDiscountAsync(Discount discount)
        {
            var oldDiscount = await _context.Discounts.FindAsync(discount.Id);
            if (oldDiscount == null)
            {
                throw new InvalidOperationException();
            }
            oldDiscount.DiscountName = discount.DiscountName;
            oldDiscount.DiscountType = discount.DiscountType;
            oldDiscount.DiscountValue = discount.DiscountValue;

            _context.Discounts.Update(oldDiscount);
            await _context.SaveChangesAsync();

            return oldDiscount.Id;
        }
    }
}