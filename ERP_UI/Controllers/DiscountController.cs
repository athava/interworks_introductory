using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ERP_UI.Models;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using ERP_UI.Enum;
using System;

namespace ERP_UI.Controllers
{
    public class DiscountController : Controller
    {
        static readonly HttpClient client = new HttpClient();
        private readonly string BackUrl = "https://localhost:44386";
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscountController"/> class.
        /// </summary>
        public DiscountController()
        {
        }
        #endregion

        #region Discount Pages
        /// <summary>
        /// Gets all Discounts.
        /// </summary>
        /// <returns>Async <see cref="ActionResult"/></returns>
        [HttpGet]
        public async Task<ActionResult> Discounts()
        {
            var response = await client.GetAsync(BackUrl + "/Discounts").ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var discounts = new DiscountsVM
            {
                Discounts = JsonConvert.DeserializeObject<IEnumerable<DiscountVM>>(content)
            };

            return View(discounts);
        }

        /// <summary>
        /// Gets a Discount details view.
        /// </summary>
        /// <returns>Async <see cref="ActionResult"/></returns>
        [HttpGet]
        public async Task<ActionResult> Discount(int discountId)
        {
            var response = await client.GetAsync(BackUrl + "/Discounts/" + discountId).ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var discount = JsonConvert.DeserializeObject<DiscountVM>(content);

            return View(discount);
        }

        /// <summary>
        /// Create Discount view model.
        /// </summary>
        /// <returns>Async <see cref="ActionResult"/></returns>
        [HttpGet]
        public async Task<ActionResult> CreateDiscount()
        {
            // TODO POPULATE DROPDOWNS
            //var response = await client.GetAsync(BackUrl + "/Customer/" + customerId).ConfigureAwait(false);
            //var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            //var customer = JsonConvert.DeserializeObject<CustomerVM>(content);
            var viewModel = new CreateUpdateDiscountVM()
            {
                DiscountTypes = new SelectList(new[] {
                    new SelectListItem {Text= System.Enum.GetName(DiscountTypeEnum.PerCent), Value = DiscountTypeEnum.PerCent.ToString()},
                    new SelectListItem {Text= System.Enum.GetName(DiscountTypeEnum.Value), Value = DiscountTypeEnum.Value.ToString()},
            }, "Value", "Text")
            };
            return View(viewModel);
        }


        /// <summary>
        /// Inserts a new Discount.
        /// </summary>
        /// <param name="viewModel">The discount data.</param>
        [HttpPost]
        public async Task<ActionResult> CreateDiscount(CreateUpdateDiscountVM viewModel)
        {
            //try
            //{
            var response = await client.PostAsync(BackUrl + "/Discounts/", new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json")).ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var newDiscountId = JsonConvert.DeserializeObject<int>(content);

            return RedirectToAction("Discount", "Discount", new
            {
                discountId = newDiscountId
            });
            //}
            //catch (Exception ex)
            //{
            //    viewModel = await _service.PopulateInsertVM(viewModel)
            //        .ConfigureAwait(true);

            //    foreach (var (key, errorMessage) in ex.ListOfErrors)
            //    {
            //        ModelState.AddModelError(key, errorMessage);
            //    }
            //    return View(viewModel);
            //}
        }

        /// <summary>
        /// Create update Discount view model.
        /// </summary>
        /// <param name="discountId" >The discount's id.</param>
        /// <returns>Async <see cref="ActionResult"/></returns>
        [HttpGet]
        public async Task<ActionResult> UpdateDiscount(int discountId)
        {
            // TODO POPULATE DROPDOWNS
            //var response = await client.GetAsync(BackUrl + "/Customer/" + customerId).ConfigureAwait(false);
            //var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            //var customer = JsonConvert.DeserializeObject<CustomerVM>(content);

            var response = await client.GetAsync(BackUrl + "/Discounts/" + discountId).ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var discountVM = JsonConvert.DeserializeObject<CreateUpdateDiscountVM>(content);
            discountVM.DiscountTypes = new SelectList(new[] {
                    new SelectListItem {Text= System.Enum.GetName(DiscountTypeEnum.PerCent), Value = DiscountTypeEnum.PerCent.ToString()},
                    new SelectListItem {Text= System.Enum.GetName(DiscountTypeEnum.Value), Value = DiscountTypeEnum.Value.ToString()},
            }, "Value", "Text");

            return View(discountVM);
        }


        /// <summary>
        /// Updates a new Discount.
        /// </summary>
        /// <param name="viewModel">The discount data.</param>
        [HttpPost]
        public async Task<ActionResult> UpdateDiscount(CreateUpdateDiscountVM viewModel)
        {
            //try
            //{
            var response = await client.PutAsync(BackUrl + "/Discounts/", new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json")).ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var newDiscountId = JsonConvert.DeserializeObject<int>(content);

            return RedirectToAction("Discount", "Discount", new
            {
                discountId = newDiscountId
            });
            //}
            //catch (Exception ex)
            //{
            //    viewModel = await _service.PopulateInsertVM(viewModel)
            //        .ConfigureAwait(true);

            //    foreach (var (key, errorMessage) in ex.ListOfErrors)
            //    {
            //        ModelState.AddModelError(key, errorMessage);
            //    }
            //    return View(viewModel);
            //}
        }

        /// <summary>
        /// Deletes a Discount.
        /// </summary>
        /// <param name="discountId">The discount identifier.</param>
        [HttpPost]
        public async Task<ActionResult> DeleteDiscount(int discountId)
        {
            //try
            //{
            var response = await client.DeleteAsync(BackUrl + "/Discounts/" + discountId).ConfigureAwait(false);
            _ = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return RedirectToAction("Discounts", "Discount");
            //}
            //catch (Exception ex)
            //{
            //    viewModel = await _service.PopulateInsertVM(viewModel)
            //        .ConfigureAwait(true);

            //    foreach (var (key, errorMessage) in ex.ListOfErrors)
            //    {
            //        ModelState.AddModelError(key, errorMessage);
            //    }
            //    return View(viewModel);
            //}
        }
        #endregion
    }
}
