using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ERP_UI.Models;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ERP_UI.Controllers
{
    public class CustomerController : Controller
    {
        static readonly HttpClient client = new HttpClient();
        private readonly string BackUrl = "https://localhost:44386";
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        public CustomerController()
        {
        }
        #endregion

        #region Customer Pages
        /// <summary>
        /// Gets the Customer search view.
        /// </summary>
        /// <returns>Async <see cref="ActionResult"/></returns>
        [HttpGet]
        public async Task<ActionResult> Customers()
        {
            var response = await client.GetAsync(BackUrl + "/Customer").ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var customers = new CustomersVM
            {
                Customers = JsonConvert.DeserializeObject<IEnumerable<CustomerVM>>(content)
            };

            return View(customers);
        }

        /// <summary>
        /// Gets a Customer details view.
        /// </summary>
        /// <returns>Async <see cref="ActionResult"/></returns>
        [HttpGet]
        public async Task<ActionResult> Customer(int customerId)
        {
            var response = await client.GetAsync(BackUrl + "/Customer/" + customerId).ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var customer = JsonConvert.DeserializeObject<CustomerVM>(content);

            return View(customer);
        }

        /// <summary>
        /// Create customer view model.
        /// </summary>
        /// <returns>Async <see cref="ActionResult"/></returns>
        [HttpGet]
        public async Task<ActionResult> CreateCustomer()
        {
            var viewModel = new CreateUpdateCustomerVM();

            var discountsResponse = await client.GetAsync(BackUrl + "/Discounts").ConfigureAwait(false);
            var discoutnsContent = await discountsResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            var discounts = JsonConvert.DeserializeObject<IEnumerable<DiscountVM>>(discoutnsContent);

            var subscriptionResponse = await client.GetAsync(BackUrl + "/Subscriptions").ConfigureAwait(false);
            var subscriptionContent = await subscriptionResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            var subscriptions = JsonConvert.DeserializeObject<IEnumerable<SubscriptionVM>>(subscriptionContent);

            var discountsSelectListItems = discounts.ToList().Select(u => new SelectListItem
            {
                Text = u.DiscountName + " - " + u.DiscountValue + " :" + u.DiscountType,
                Value = u.Id.ToString()
            });
            var subscriptionSelectListItems = subscriptions.ToList().Select(u => new SelectListItem
            {
                Text = u.SubscriptionName + "-" + u.SubscriptionPrice,
                Value = u.Id.ToString()
            });
            viewModel.Discounts = new SelectList(discountsSelectListItems, "Value", "Text");
            viewModel.Subscriptions = new SelectList(subscriptionSelectListItems, "Value", "Text");


            return View(viewModel);
        }


        /// <summary>
        /// Inserts a new customer.
        /// </summary>
        /// <param name="viewModel">The customer data.</param>
        [HttpPost]
        public async Task<ActionResult> CreateCustomer(CreateUpdateCustomerVM viewModel)
        {
            //try
            //{
            var response = await client.PostAsync(BackUrl + "/Customer/", new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json")).ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var newCustomerId = JsonConvert.DeserializeObject<int>(content);

            return RedirectToAction("Customer", "Customer", new
            {
                customerId = newCustomerId
            });
        }

        /// <summary>
        /// Create update customer view model.
        /// </summary>
        /// <param name="customerId" >The customer's id.</param>
        /// <returns>Async <see cref="ActionResult"/></returns>
        [HttpGet]
        public async Task<ActionResult> UpdateCustomer(int customerId)
        {
            var response = await client.GetAsync(BackUrl + "/Customer/" + customerId).ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var customerVM = JsonConvert.DeserializeObject<CreateUpdateCustomerVM>(content);

            return View(customerVM);
        }


        /// <summary>
        /// Updates a new customer.
        /// </summary>
        /// <param name="viewModel">The customer data.</param>
        [HttpPost]
        public async Task<ActionResult> UpdateCustomer(CreateUpdateCustomerVM viewModel)
        {
            var response = await client.PutAsync(BackUrl + "/Customer/", new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json")).ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var newCustomerId = JsonConvert.DeserializeObject<int>(content);

            return RedirectToAction("Customer", "Customer", new
            {
                customerId = newCustomerId
            });
        }

        /// <summary>
        /// Deletes a customer.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        [HttpPost]
        public async Task<ActionResult> DeleteCustomer(int customerId)
        {
            var response = await client.DeleteAsync(BackUrl + "/Customer/" + customerId).ConfigureAwait(false);
            _ = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return RedirectToAction("Customers", "Customer");
        }
        #endregion
    }
}
