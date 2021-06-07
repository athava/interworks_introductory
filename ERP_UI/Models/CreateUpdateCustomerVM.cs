using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ERP_UI.Models
{
    public class CreateUpdateCustomerVM
    {
        public int Id { get; set; }

        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Customer name is required")]
        public string CustomerName { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "Customer Type is required")]
        public string CustomerType { get; set; }

        public int? DiscountId { get; set; }
        public int? SubscriptionId { get; set; }

        public SelectList Discounts { get; set; }

        public SelectList Subscriptions { get; set; }
    }
}
