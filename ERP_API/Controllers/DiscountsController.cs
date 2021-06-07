using ERP_API.CustomExceptions;
using ERP_API.DTOs;
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
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountsService _discountService;
        private readonly ILogger _logger;

        public DiscountsController(IDiscountsService discountService, ILogger<DiscountsController> logger)
        {
            _discountService = discountService ?? throw new ArgumentNullException(nameof(discountService));
            _logger = logger;
        }

        /// <summary>
        /// Gets all Discounts.
        /// </summary>
        /// <returns><see cref="IEnumerable{CustomerDTO}" /></returns>
        [HttpGet]
        public async Task<IEnumerable<DiscountDTO>> GetAllDiscountsAsync()
        {
            return await _discountService.GetAllDiscountsAsync();
        }

        /// <summary>
        /// Get a specific Discount.
        /// </summary>
        /// <param name="discountId">The discount's id.</param>
        /// <returns><see cref="ActionResult" /></returns>
        [HttpGet]
        [Route("{discountId}")]
        public async Task<ActionResult> GetDiscountAsync(int discountId)
        {
            try
            {
                return Ok(await _discountService.GetDiscountAsync(discountId).ConfigureAwait(false));
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
        /// Add a new Discount.
        /// </summary>
        /// <param name="discount">A discount.</param>
        /// <returns><see cref="ActionResult" /></returns>
        [HttpPost]
        public async Task<ActionResult> AddDiscountAsync(DiscountDTO discount)
        {
            try
            {
                var newDiscountId = await _discountService.AddDiscountAsync(discount);
                return Ok(newDiscountId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing Discount.
        /// </summary>
        /// <param name="discount">A discount.</param>
        /// <returns><see cref="ActionResult" /></returns>
        [HttpPut]
        public async Task<ActionResult> UpdateDiscountAsync(DiscountDTO discount)
        {
            try
            {
                var discountId = await _discountService.UpdateDiscountAsync(discount).ConfigureAwait(false);
                return Ok(discountId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deletes the specified Discount.
        /// </summary>
        /// <param name="discountId">The discount's id.</param>
        /// <returns><see cref="ActionResult" /></returns>
        [HttpDelete]
        [Route("{discountId}")]
        public async Task<ActionResult> DeleteDiscountAsync(int discountId)
        {
            try
            {
                await _discountService.DeleteDiscountAsync(discountId).ConfigureAwait(false);
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
