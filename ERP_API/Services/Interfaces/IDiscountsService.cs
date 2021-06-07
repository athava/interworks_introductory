using ERP_API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_API.Services.Interfaces
{
    public interface IDiscountsService
    {
        /// <summary>
        /// Gets all discounts.
        /// </summary>
        /// <returns><see cref="IEnumerable{DiscountDTO}"/>List with active discounts.</returns>
        Task<IEnumerable<DiscountDTO>> GetAllDiscountsAsync();

        /// <summary>
        /// Get a specific discount.
        /// </summary>
        /// <param name="discountId" >The discount's id.</param>
        /// <returns><see cref="CustomException"/>The discount with the specified id.</returns>
        /// <exception cref="ArgumentOutOfRangeException">discount id is not valid.</exception>
        /// <exception cref="Custom">discount not found.</exception>
        Task<DiscountDTO> GetDiscountAsync(int discountId);

        /// <summary>
        /// Add a new discount.
        /// </summary>
        /// <param name="discount">A discount.</param>
        /// <exception cref="ArgumentNullException">discount is not valid.</exception>
        /// <exception cref="ArgumentException">discountType or discountTitle are not valid.</exception>
        /// <returns><see cref="int"/> the discount new identifier.</returns>
        Task<int> AddDiscountAsync(DiscountDTO discount);

        /// <summary>
        /// Updates an existing discount.
        /// </summary>
        /// <param name="discount">A discount.</param>
        /// <exception cref="ArgumentNullException">discount is not valid.</exception>
        /// <exception cref="ArgumentException">discountType or discountTitle are not valid.</exception>
        /// <returns><see cref="int"/> the discount new identifier.</returns>
        Task<int> UpdateDiscountAsync(DiscountDTO discount);

        /// <summary>
        /// Deletes the specified discount.
        /// </summary>
        /// <param name="discountId">The discount's id.</param>
        /// <exception cref="ArgumentOutOfRangeException">discount id is not valid.</exception>
        Task DeleteDiscountAsync(int discountId);
    }
}
