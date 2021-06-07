using ERP_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_API.Repositories.Interfaces
{
    public interface IDiscountsRepository
    {
        /// <summary>
        /// Gets all discounts.
        /// </summary>
        /// <returns><see cref="IEnumerable{Discount}"/>List with active discounts.</returns>
        Task<IEnumerable<Discount>> GetAllDiscountsAsync();

        /// <summary>
        /// Get a specific discount.
        /// </summary>
        /// <param name="discountId" >The discount's id.</param>
        /// <returns><see cref="CustomException"/>The discount with the specified id.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Discount id is not valid.</exception>
        /// <exception cref="Custom">Discount not found.</exception>
        Task<Discount> GetDiscountAsync(int discountId);

        /// <summary>
        /// Add a new discount.
        /// </summary>
        /// <param name="discount">A discount.</param>
        /// <exception cref="ArgumentNullException">discount is not valid.</exception>
        /// <exception cref="ArgumentException">discountType or discountTitle are not valid.</exception>
        /// <returns><see cref="int"/> the discount new identifier.</returns>
        Task<int> AdddiscountAsync(Discount discount);

        /// <summary>
        /// Updates an existing discount.
        /// </summary>
        /// <param name="discount">A discount.</param>
        /// <exception cref="ArgumentNullException">Discount is not valid.</exception>
        /// <exception cref="ArgumentException">DiscountType or discountTitle are not valid.</exception>
        /// <returns><see cref="int"/> the discount new identifier.</returns>
        Task<int> UpdateDiscountAsync(Discount discount);

        /// <summary>
        /// Deletes the specified discount.
        /// </summary>
        /// <param name="discountId">The discount's id.</param>
        /// <exception cref="ArgumentOutOfRangeException">Discount id is not valid.</exception>
        Task DeleteDiscountAsync(int discountId);
    }
}
