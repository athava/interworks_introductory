using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ERP_UI.Models
{
    public class CreateUpdateDiscountVM
    {
        public int Id { get; set; }

        [Display(Name = "Discount Name")]
        [Required(ErrorMessage = "Discount name is required")]
        public string DiscountName { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "Discount Type is required")]
        public string DiscountType { get; set; }


        [Display(Name = "Value")]
        [Required(ErrorMessage = "Discount Value is required")]
        public float DiscountValue { get; set; }

        public SelectList DiscountTypes { get; set; }
    }
}
