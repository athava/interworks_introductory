using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ERP_UI.Models;
using System.Collections.Generic;
using System.Text;

namespace ERP_UI.Controllers
{
    public class SubscriptionController : Controller
    {
        static readonly HttpClient client = new HttpClient();
        private readonly string BackUrl = "https://localhost:44386";
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionController"/> class.
        /// </summary>
        public SubscriptionController()
        {
        }
        #endregion

        #region Subscription pages
        /// <summary>
        /// Gets all the Subscriptions.
        /// </summary>
        /// <returns>Async <see cref="ActionResult"/></returns>
        [HttpGet]
        public async Task<ActionResult> Subscriptions()
        {
            var response = await client.GetAsync(BackUrl + "/Subscriptions").ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var subscriptions = new SubscriptionsVM
            {
                Subscriptions = JsonConvert.DeserializeObject<IEnumerable<SubscriptionVM>>(content)
            };

            return View(subscriptions);
        }
        #endregion
    }
}
