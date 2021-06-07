using System;
using System.Collections.Generic;

#nullable disable

namespace ERP_API.Models
{
    public partial class Discount
    {
        public Discount()
        {
            SubscriptionDiscounts = new HashSet<SubscriptionDiscount>();
        }

        public int Id { get; set; }
        public string DiscountName { get; set; }
        public string DiscountType { get; set; }
        public double? DiscountValue { get; set; }

        public virtual ICollection<SubscriptionDiscount> SubscriptionDiscounts { get; set; }
    }
}
