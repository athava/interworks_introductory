using System;
using System.Collections.Generic;

#nullable disable

namespace ERP_API.Models
{
    public partial class SubscriptionDiscount
    {
        public int Id { get; set; }
        public int CustomerSubscriptionId { get; set; }
        public int DiscountId { get; set; }

        public virtual CustomerSubscription CustomerSubscription { get; set; }
        public virtual Discount Discount { get; set; }
    }
}
